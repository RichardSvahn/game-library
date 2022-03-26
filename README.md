# game-library
</salt> one-day hackday project

This started as a one-day challenge during my coding bootcamp at </salt>, and is currently in its "original" form. I intend to keep building on it as a learning project, however.

It uses a localhost Docker image as database, .Net WebAPI with Entity Framework as backend, and a React Typescript frontend.

The project can be run after running the following commands in the terminal:

1. \game-library\ : "docker-compose up -d"
-This will, assuming you have Docker installed, mount and run the image for the database

2. \game-library\GameLibrary.API : "dotnet restore"
-Installs all dependencies for the .Net backend

3. \game-library\GameLibrary.API : "dotnet ef database update"
-Updates the database to the latest migration, creating the tables needed

4. \game-library\GameLibrary.API : "dotnet run"
-This is going to start the API backend service

5. \game-library\GameLibrary.Client : "npm install"
-This will install all node module dependencies necessary

6. \game-library\GameLibrary.Client : "npm start"
-Starts the React frontend

You will now be able to access the page on https://localhost:3000, and also use Swagger on the backend, e.g. https://localhost:7264/swagger/


Todo:
Add full CRUD on frontend (missing edit/delete)
Fix CSS scrolling area
Add proper routing to more fleshed out details page
Add ability to add notes to game
Check for potential external API (Steam?) for picture/description import
Write startup/install script
