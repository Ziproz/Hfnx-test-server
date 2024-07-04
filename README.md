# FnxTest

GitHub Repositories Search Project
This project is a web application that allows users to search for GitHub repositories and bookmark their favorite ones. The application is built using Angular 17 for the frontend and .NET Core 8 for the backend. The project also includes user authentication using JWT and session management using Redis.

Table of Contents
Prerequisites
Installation
Running the Application
Usage
Project Structure
Prerequisites
Make sure you have the following software installed on your system:

Node.js (version 14 or higher)
Angular CLI (version 17)
.NET SDK (version 8)
Redis
Installation
Clone the repository
bash
Copy code
git clone https://github.com/your-username/github-repositories-search.git
cd github-repositories-search
Backend
Navigate to the backend project directory:

bash
Copy code
cd FnxTest
Install the required NuGet packages:

bash
Copy code
dotnet restore
Configure Redis:

Make sure Redis is installed and running on your system. The default connection string is used in the appsettings.json file:

json
Copy code
"ConnectionStrings": {
  "Redis": "localhost:6379"
}
Frontend
Navigate to the frontend project directory:

bash
Copy code
cd angular-app
Install the required npm packages:

bash
Copy code
npm install
Running the Application
Backend
Start the .NET application:

bash
Copy code
dotnet run
The backend server will run at http://localhost:5000.

Frontend
Start the Angular application:

bash
Copy code
ng serve
The frontend server will run at http://localhost:4200.

Usage
Open your browser and navigate to http://localhost:4200.
You will be redirected to the login page.
Use the following credentials to log in:
Username: testuser
Password: password
Once logged in, you can search for GitHub repositories and bookmark them.
Project Structure
Backend (FnxTest)
Program.cs: Entry point of the application. Configures services and middleware.
Controllers: Contains the API controllers.
Services: Contains the service classes for handling business logic.
Models: Contains the model classes.
appsettings.json: Configuration file for application settings.
Frontend (angular-app)
src/app: Contains the Angular components, services, and modules.
src/app/app-routing.module.ts: Configures the application routes.
src/app/components: Contains the Angular components (e.g., login, search).
src/app/services: Contains the Angular services for handling HTTP requests.
src/app/interceptors: Contains the Angular HTTP interceptors (e.g., JWT, spinner).
