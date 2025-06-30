import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root' // Makes the service available app-wide
})
export class AuthService {
  // Base URL of backend API
  private baseUrl = 'https://localhost:7049/api/auth';

  constructor(private http: HttpClient) { }

  // Login method that returns Observable of plain text
  login(username: string, password: string): Observable<string> {
    const params = { username, password };
    return this.http.post(this.baseUrl + '/login', {}, { params, responseType: 'text' });
  }

  // Register method that returns Observable of plain text
  register(username: string, email: string, password: string): Observable<string> {
    const params = { username, email, password };
    return this.http.post(this.baseUrl + '/register', {}, { params, responseType: 'text' });
  }
}
