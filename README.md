# Steven's Movies

A movie management web application built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQLite** as part of the BYU-Idaho CSE 325 course.

## Features

- **Movie Management (CRUD):** Create, view, edit, and delete movies.
- **Search:** Search movies by title.
- **Year Filter:** Filter movies by release year or newer.
- **Movie Details:** Display title, release date, genre, price, and rating.
- **Data Validation:** Validate required fields, string lengths, and price ranges.
- **Responsive Interface:** Built with Bootstrap and custom CSS styling.

## Technologies Used

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Bootstrap
- HTML and CSS
- Razor Views

## Movie Properties

Each movie contains the following information:

| Property | Description |
|---|---|
| Id | Unique movie identifier |
| Title | Movie title |
| ReleaseDate | Release date |
| Genre | Movie genre |
| Price | Movie price |
| Rating | Movie classification |

## Getting Started

### Prerequisites

- .NET SDK 10.0 or later
- Visual Studio Code (recommended)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/stenvesitosava/CSE-325.git
   ```

2. Navigate to the project directory:

   ```bash
   cd CSE-325
   ```

3. Switch to the Week 02 branch:

   ```bash
   git switch week-02
   ```

4. Navigate to the application folder:

   ```bash
   cd StevenMovies
   ```

5. Restore dependencies:

   ```bash
   dotnet restore
   ```

6. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

7. Run the application:

   ```bash
   dotnet run
   ```

8. Open the local URL displayed in the terminal.

## Sample Movies

The application includes the following sample movies:

- Interstellar (2014)
- The Dark Knight (2008)
- Inception (2010)

## Author

**Steven Savarin**

BYU-Idaho – CSE 325: .NET Software Development

GitHub: [@stenvesitosava](https://github.com/stenvesitosava)