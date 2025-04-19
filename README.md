
# Flashcard Application

This is a Flashcard application built using Blazor, Dapper, MSSQL, and stored procedures. The app allows users to create, view, and study flashcards efficiently.

## Features

- **Create Flashcards**: Users can add new flashcards with a question and answer.
- **View Flashcards**: Flashcards are displayed in a list for easy review.
- **Study Mode**: A study mode is available to test your knowledge with flashcards.
- **Persistent Storage**: The app uses MSSQL as a database to store flashcards.
- **Dapper for Data Access**: Dapper is used for efficient data access with stored procedures.

## Technologies Used

- **Blazor**: A framework for building interactive web UIs with C#.
- **Dapper**: A lightweight ORM for .NET that helps with querying and mapping data to objects.
- **MSSQL**: A relational database to store flashcards data.
- **Stored Procedures**: SQL stored procedures are used for interacting with the database.

## Getting Started

To get started with this application, follow these steps:

### Prerequisites

Make sure you have the following installed:

- .NET SDK (6.0 or higher)
- MSSQL
- Visual Studio or Visual Studio Code
- Dapper NuGet Package

### Clone the Repository

```bash
git clone https://github.com/prabesh-stha/FlashCardBlazor.git
cd FlashCardBlazor
```

### Setup the Database

1. Create a MSSQL database for the Flashcard application.
   
2. Run the following SQL scripts to create the required tables and stored procedures:

   ```sql
   -- Create the Flashcards table
   CREATE TABLE Flashcards (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Question VARCHAR(255) NOT NULL,
       Answer VARCHAR(255) NOT NULL,
   );
   
   -- Stored Procedure to get all flashcards
   CREATE PROCEDURE GetAllFlashcard
   BEGIN
       SELECT * FROM Flashcards;
   END;

   -- Stored Procedure to insert a new flashcard
   CREATE PROCEDURE AddFlashcard
    @Question VARCHAR(255), @Answer VARCHAR(255)
   AS
   BEGIN
       INSERT INTO Flashcards (Question, Answer, Description)
       VALUES (p_question, p_answer, p_description);
   END;
   ```

3. Update the connection string in `appsettings.json` to match your MSSQL database configuration:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=flashcarddb;User=root;Password=yourpassword;"
     }
   }
   ```

### Install Dependencies

Run the following command to install the required NuGet packages:

```bash
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

### Run the Application

After setting up the database and updating the connection string, you can run the application:

```bash
dotnet run
```

## Stored Procedures

### GetFlashcardById
```sql
CREATE PROCEDURE GetFlashcard
@Id INT
AS
BEGIN
SELECT * FROM Flashcards WHERE Id = @Id;
END;
```


### GetAllFlashcards

```sql
CREATE PROCEDURE GetAllFlashcard
BEGIN
    SELECT * FROM Flashcards;
END;
```

This stored procedure retrieves all flashcards from the database.

### AddFlashcard

```sql
   CREATE PROCEDURE AddFlashcard
    @Question VARCHAR(255), @Answer VARCHAR(255)
   AS
   BEGIN
       INSERT INTO Flashcards (Question, Answer, Description)
       VALUES (p_question, p_answer, p_description);
   END;
```
### UpdateFlashcard

```sql
   CREATE PROCEDURE UpdateFlashcard
    @Id INT, @Question VARCHAR(255), @Answer VARCHAR(255)
   AS
   BEGIN
       UPDATE Flashcards SET Question = @Question, Answer = @Answer WHERE Id = @Id;
   END;
```
### DeleteFlashcard

```sql
   CREATE PROCEDURE DeleteFlashcard
    @Id INT
   AS
   BEGIN
       DELETE FROM Flashcards WHERE Id = @Id;
   END;
```

This stored procedure adds a new flashcard to the database.