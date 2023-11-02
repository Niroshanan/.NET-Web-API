# DCE_API_ASSIGNMENT

Welcome to the .Net Web API project! This .NET WebAPI project allows you to perform CRUD (Create, Read, Update, Delete) operations on customer details and retrieve active orders through API calls. Below, you'll find instructions on how to set up and use this project.

## Cloning the Repository
To get started, clone this repository using the following command:

```bash
git clone https://github.com/Niroshanan/DCE_API_ASSIGNMENT.git
```
## Project Setup
1. Open the solution file `DCE_API_ASSIGNMENT.sln` in Visual Studio.
2. Build the solution to restore NuGet packages and ensure everything is set up correctly.

## API Endpoints
This project exposes the following API endpoints:

### Create Customer
- **Endpoint:** `POST /api/Customer/Create`
- **Description:** Create a new customer.
- **Request Body:** JSON object representing the customer details.
- **Example Request:**
  ```http
  POST https://localhost:7212/api/Customer/Create
  Content-Type: application/json
  
  {
  "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
  "username": "Customer1",
  "email": "Customer1@gmail.com",
  "firstName": "Customer1firstName",
  "lastName": "CustomerlastName",
  "isActive": true
  }
- **Response:** JSON object representing the created customer with a unique ID.
### Get All Customers
- **Endpoint:** `GET /api/Customer/GetAll`
- **Description:** Retrieve a list of all customers.
- **Response:** JSON array containing customer objects.
- **Example Request:**
  ```http
  GET https://localhost:7212/api/Customer/GetAll
  
### Update Customer
- **Endpoint:** POST /api/Customer/Update
- **Description:** Update an existing customer's details.
- **Example Request:**
  ```http
  POST https://localhost:7212/api/Customer/Update
  Content-Type: application/json
  {
    "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa7",
    "username": "Nirosh12",
    "email": "abc@gmail.com",
    "firstName": "Sathananthan",
    "lastName": "Niroshanan",
    "isActive": true
  }

### Delete Customer
- **Endpoint:** DELETE /api/Customer/Delete/{Id}
- **Description:** Delete a customer by their ID.
- **Example Request:**
  ```http
  DELETE https://localhost:7212/api/Customer/delete/3fa85f64-5717-4562-b3fc-2c963f66afa7

### Get Active Orders by Customer ID
- **Endpoint:** GET /api/Customer/Active/{Id}
- **Description:** Retrieve active orders for a specific customer by their ID.
- **Response:** JSON array containing active order objects.
- **Example Request:**
  ```http
  GET https://localhost:7212/api/Customer/Active/4CF392FB-A291-444A-8A64-203D2392CFB4

### Get All Active Orders
- **Endpoint:** GET /api/Customer/ActiveOrders
- **Description:** Retrieve a list of all active orders for all customers.
- **Response:** JSON array containing active order objects.
- **Example Request:**
  ```http
  GET https://localhost:7212/api/Customer/ActiveOrders
  
### Usage
You can use your favorite API client (e.g., Postman, cURL) to make requests to the provided API endpoints. Ensure that the project is running, and the base URL matches your environment.
For example, you can create a new customer using a POST request to `https://localhost:7212/api/Customer/Create` with the appropriate JSON request body.

Feel free to explore and utilize these endpoints to manage customer data and retrieve active orders.







