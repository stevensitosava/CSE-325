# CSE-325 --- W01 Assignment: Build .NET Applications with C

This repository contains the work for the BYU-Idaho W01 assignment. It
includes an ASP.NET Core Web API for managing pizzas and a C# console
application that reads sales files and generates a sales summary report.

## Project structure

``` text
CSE-325/
├── PizzaAPI/
│   ├── Controllers/
│   │   └── PizzaController.cs
│   ├── Models/
│   │   └── Pizza.cs
│   ├── Program.cs
│   └── PizzaAPI.csproj
│
├── SalesSummary/
│   ├── Sales/
│   │   ├── sales_january.txt
│   │   ├── sales_february.txt
│   │   └── sales_summary.txt
│   ├── Program.cs
│   └── SalesSummary.csproj
│
└── README.md
```

## Requirements

-   .NET SDK installed.
-   Visual Studio Code or another C# development environment.
-   Postman (or another HTTP client) to test the API.

## Part 1: Pizza API

The `PizzaAPI` project is an ASP.NET Core Web API. It provides CRUD
operations for pizzas.

### Run the API

Open a terminal in the `PizzaAPI` directory and run:

``` bash
dotnet restore
dotnet run
```

Use the local address printed in the terminal. For example:

``` text
http://localhost:5276
```

The port may be different on your computer.

### API endpoints

Replace the base URL below with the address printed by `dotnet run`.

  --------------------------------------------------------------------------
  HTTP method       Endpoint            Description       Expected response
  ----------------- ------------------- ----------------- ------------------
  GET               `/api/pizza`        Returns all       `200 OK`
                                        pizzas            

  GET               `/api/pizza/{id}`   Returns one pizza `200 OK` or
                                                          `404 Not Found`

  POST              `/api/pizza`        Creates a pizza   `201 Created`

  PUT               `/api/pizza/{id}`   Updates a pizza   `204 No Content`
                                                          or `404 Not Found`

  DELETE            `/api/pizza/{id}`   Deletes a pizza   `204 No Content`
                                                          or `404 Not Found`
  --------------------------------------------------------------------------

### Example POST request

Set the request method to `POST`, choose **Body → raw → JSON**, and
send:

``` json
{
  "name": "Four Cheese",
  "price": 16.50,
  "description": "Mozzarella, parmesan, cheddar and gorgonzola"
}
```

### Example PUT request

Set the request method to `PUT`, use `/api/pizza/1`, and send:

``` json
{
  "name": "Margherita Special",
  "price": 18.00,
  "description": "Tomato, mozzarella, basil and parmesan"
}
```

The API currently stores pizza records in an in-memory list. Data is
reset when the API process restarts; no database is configured.

## Part 2: Sales Summary application

The `SalesSummary` project is a C# console application. It reads `.txt`
files from the `Sales` directory, adds the valid numeric amounts,
displays the total for each file, calculates the overall total, and
writes the report to `Sales/sales_summary.txt`.

### Run the application

Open a terminal in the `SalesSummary` directory and run:

``` bash
dotnet restore
dotnet run
```

### Sample input

`Sales/sales_january.txt`:

``` text
120.50
250.00
130.25
```

`Sales/sales_february.txt`:

``` text
300.00
150.50
200.00
```

### Sample result

``` text
SALES SUMMARY

sales_february.txt: $650.50
sales_january.txt: $500.75

TOTAL SALES: $1,151.25
```

The exact order of the file details may vary. The generated report is
saved as `Sales/sales_summary.txt`.

## Testing evidence

Screenshots of the following API tests should be included with the
assignment submission:

-   GET: retrieve the pizza list.
-   POST: create a pizza.
-   PUT: update a pizza.
-   DELETE: delete a pizza.

Also include evidence showing the Sales Summary application running and
the generated `sales_summary.txt` report.

## Notes

This repository was created as coursework for the BYU-Idaho CSE-325 W01
assignment. The projects are separate .NET applications and should be
run from their respective directories.

Steven Savarin
