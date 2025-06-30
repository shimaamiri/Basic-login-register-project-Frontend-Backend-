# 🔐 User Authentication Platform

This project is a complete full-stack authentication system built from scratch using modern web development technologies. It provides the basic functionality for user registration and login, following secure and organized coding principles.

The platform demonstrates how a frontend Angular application communicates with a .NET 8 backend through RESTful APIs, using a clean, responsive UI with form validation and user feedback. The backend securely stores user credentials using password hashing and ensures database consistency via Entity Framework Core.

The system is intentionally built with clarity, separation of concerns, and easy maintainability in mind.

---

## 🌐 Technologies Used

**Frontend**
- Angular 17
- TypeScript
- CSS Flexbox (for layout)

**Backend**
- ASP.NET Core 8.0 (C#)
- Entity Framework Core
- SQL Server LocalDB

**Tools**
- Visual Studio 2022
- Node.js + NPM
- Angular CLI
- Swagger (for API testing)

---

## 🧱 Backend Structure (ASP.NET Core)

### 📁 `Controllers/AuthController.cs`
This controller defines the HTTP endpoints:
- `POST /api/auth/register` — Handles account creation
- `POST /api/auth/login` — Handles user authentication

Each endpoint receives parameters, calls the business logic service (`AuthService`), and returns appropriate responses (success or error messages).



### 📁 `Services/AuthService.cs`
Contains all the business logic related to authentication. Its responsibilities include:
- Checking if a user exists
- Hashing passwords before saving
- Verifying hashed passwords during login
- Interacting with the database through the `AppDbContext`

This separation ensures that the controller remains clean and focused on routing.



### 📁 `Models/User.cs`
Defines the structure of the `User` entity as stored in the database. Includes:
- `Id`: Primary key
- `Username`: Unique name for login
- `Email`: User’s email address
- `PasswordHash`: Hashed version of the password

This model is used both for storing user data and for validation.



### 📁 `Data/AppDbContext.cs`
The database context used by Entity Framework Core to interact with the `Users` table in the SQL Server database. It maps the `User` model to the actual table and manages DB queries and migrations.



### 🗂 `Program.cs`
This is the main entry point of the backend API. It:
- Configures services (EF Core, controllers, AuthService)
- Enables CORS for communication with Angular
- Configures the database connection
- Sets up Swagger for API testing
- Runs the web server

---

## 🖼️ Frontend Structure (Angular)

### 📁 `src/app/home/`
This is the **login component**. It:
- Displays a login form with username and password fields
- Submits data to the backend using the `AuthService`
- Shows a success message and a greeting on successful login
- Offers a button to navigate to the Register page

It also handles client-side validation and UI state like showing errors or logging out.



### 📁 `src/app/register/`
This is the **registration component**. It:
- Displays a form with username, email, and password
- Sends the data to the backend’s `/register` endpoint
- Shows a success or error message after the response
- Has a cancel button to return to the login page

Like the login component, it uses Angular’s form binding and HTTP client for backend integration.


### 📁 `src/app/services/auth.service.ts`
A shared service used by both components (`Home`, `Register`) to communicate with the backend. It:
- Sends login and registration requests
- Returns observable responses
- Keeps HTTP logic separate from the UI components

This service allows code reuse and keeps components focused on UI logic.


### 📁 `app-routing.module.ts`
Defines routing for the application. It includes:
- `/` → HomeComponent (Login page)
- `/register` → RegisterComponent

Enables navigation between login and registration forms.


### 📁 `app.component.html`
Stripped down to a single line:


<router-outlet></router-outlet>


This ensures that only the routed components (Home, Register) are shown, keeping the layout clean and simple.

---
## 🚀 How to Run the Project

- Download the project in `C:\Users\user\Downloads` and extract it.
-Then first Run the backend and after that run the frontend.

### 🖥️ Running the Backend
- Press F5 or click Run to start the backend API 
- Test endpoints with Swagger (usually at https://localhost:port/swagger).

### 🌐 Running the Frontend
- cd auth-project
- ng serve
- Open your browser and go to http://localhost:4200


---
## 👩‍💻 `Developed by:`
Shima Amiri Fard
