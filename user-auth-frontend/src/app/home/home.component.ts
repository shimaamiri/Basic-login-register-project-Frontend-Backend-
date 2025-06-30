import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  // User input fields
  username: string = '';
  password: string = '';

  // Display message for success or error
  message: string = '';

  // Controls whether user is logged in
  loggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }

  // Handle login logic
  login() {
    // Call the AuthService to make HTTP POST to backend
    this.authService.login(this.username, this.password).subscribe({
      next: res => {
        // If login successful, show greeting
        this.message = res;
        this.loggedIn = true;
      },
      error: err => {
        // Display error message based on response
        if (err.error && typeof err.error === 'string') {
          this.message = err.error;
        } else if (err.status === 0) {
          this.message = 'Could not reach the server.';
        } else {
          this.message = 'Unexpected error during login.';
        }
      }
    });
  }

  // Navigate to the Register page
  goToRegister() {
    this.router.navigate(['/register']);
  }

  // Logout and reset the form
  logout() {
    this.loggedIn = false;
    this.username = '';
    this.password = '';
    this.message = '';
  }
}
