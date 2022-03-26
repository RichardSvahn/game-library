# game-library
&lt;&#47;salt> one-day hackday project<br>

This started as a one-day challenge during my coding bootcamp at &lt;&#47;salt>, and is currently in its "original" form. I intend to keep building on it as a learning project, however.<br>

It uses a localhost Docker image as database, .Net WebAPI with Entity Framework as backend, and a React Typescript frontend.<br>

The project can be run after running the following commands in the terminal:

1. \game-library\ : "docker-compose up -d"<br>
-This will, assuming you have Docker installed, mount and run the image for the database<br>

2. \game-library\GameLibrary.API : "dotnet restore"<br>
-Installs all dependencies for the .Net backend<br>

3. \game-library\GameLibrary.API : "dotnet ef database update"<br>
-Updates the database to the latest migration, creating the tables needed<br>

4. \game-library\GameLibrary.API : "dotnet run"<br>
-This is going to start the API backend service<br>

5. \game-library\GameLibrary.Client : "npm install"<br>
-This will install all node module dependencies necessary<br>

6. \game-library\GameLibrary.Client : "npm start"<br>
-Starts the React frontend<br>
<br>
You will now be able to access the page on https://localhost:3000, and also use Swagger on the backend, e.g. https://localhost:7264/swagger/<br>
<br>
<br>
Todo:<br>
Add full CRUD on frontend (missing edit/delete) <br>
Fix CSS scrolling area<br>
Add proper routing to more fleshed out details page<br>
Add ability to add notes to game<br>
Check for potential external API (Steam?) for picture/description import<br>
Write startup/install script<br>
