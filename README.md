# FnxTest

GitHub Repositories Search Project
This project is a web application that allows users to search for GitHub repositories and bookmark their favorite ones. The application is built using Angular 17 for the frontend and .NET Core 8 for the backend. The project also includes user authentication using JWT and session management using Redis.

# Table of Contents
Prerequisites<br />
Installation<br />
Running the Application<br />
Usage<br />
Project Structure<br />

# Prerequisites
Make sure you have the following software installed on your system:<br />
Node.js (version 14 or higher)<br />
Angular CLI (version 17)<br />
.NET SDK (version 8)<br />
Redis -> Download zip file from: https://github.com/microsoftarchive/redis, extract the files, and run redis-server.exe

# Installation
Clone the repository<br />
Install the required NuGet packages<br />
Configure Redis: <br />
Make sure Redis is installed and running on your system. The default connection string is used in the appsettings.json file<br />

Frontend<br />
Navigate to the frontend project directory<br />
Install the required npm packages:npm install

# Running the Application
Backend
Start the .NET application:dotnet run
The backend server will run at http://localhost:5000.<br />

Frontend
Start the Angular application:ng serve
The frontend server will run at http://localhost:4200.

# Usage
Open your browser and navigate to http://localhost:4200.
You will be redirected to the login page.
Use the following credentials to log in:
Username: testuser
Password: password
Once logged in, you can search for GitHub repositories and bookmark them.

# Project Structure
Backend (FnxTest)<br />
Program.cs: Entry point of the application. Configures services and middleware.<br />
Routes: Contains the API endpoints.<br />
Contract: Contains the interfaces<br />
Services: Contains the service classes for handling business logic.<br />
Models: Contains the model classes.<br />
appsettings.json: Configuration file for application settings.<br /><br />
Frontend (hfnx-test)<br />
src/app: Contains the Angular components, services, and modules.<br />
src/app/routes.ts: Configures the application routes.<br />
src/app/components: Contains the Angular components (e.g., login, search).<br />
src/app/services: Contains the Angular services for handling HTTP requests.<br />
src/app/interceptors: Contains the Angular HTTP interceptors (e.g., JWT, spinner).<br />
