import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  // Input fields for new user
  username: string = '';
  email: string = '';
  password: string = '';

  // Display success or error message
  message: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  // Handle user registration
  register() {
    // Call AuthService to POST user registration to backend
    this.authService.register(this.username, this.email, this.password).subscribe({
      next: res => {
        // Show success message
        this.message = res;
      },
      error: err => {
        // Display error based on response
        if (err.error && typeof err.error === 'string') {
          this.message = err.error;
        } else if (err.status === 0) {
          this.message = 'Could not reach the server.';
        } else {
          this.message = 'Unexpected error during registration.';
        }
      }
    });
  }

  // Go back to login/home page
  goHome() {
    this.router.navigate(['/']);
  }
}
