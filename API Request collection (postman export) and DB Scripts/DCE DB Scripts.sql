CREATE TABLE Customer (
    UserId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username VARCHAR(30),
    Email VARCHAR(20),
    FirstName VARCHAR(20),
    LastName VARCHAR(20),
    CreatedOn DATETIME,
    IsActive BIT
);

CREATE TABLE Supplier (
    SupplierId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SupplierName VARCHAR(50),
    CreatedOn DATETIME,
    IsActive BIT
);

CREATE TABLE Product (
    ProductId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ProductName VARCHAR(50),
    UnitPrice DECIMAL(18, 2),
    SupplierId UNIQUEIDENTIFIER,
    CreatedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (SupplierId) REFERENCES Supplier(SupplierId)
);

CREATE TABLE [Order] (
    OrderId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ProductId UNIQUEIDENTIFIER,
    OrderStatus INT,
    OrderType INT,
    OrderBy UNIQUEIDENTIFIER,
    OrderedOn DATETIME,
    ShippedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (OrderBy) REFERENCES Customer(UserId)
);


CREATE PROCEDURE GetActiveOrdersByCustomer
    @CustomerId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT*
    FROM
        [Order] O
    WHERE
        O.OrderBy = @CustomerId
        AND O.IsActive = 1;  
END;



CREATE PROCEDURE ActiveOrdersByCustomer
AS
BEGIN
    SELECT [order].OrderId,[order].ProductId,[order].OrderBy, product.ProductName,product.UnitPrice,product.SupplierId,Supplier.SupplierName
    FROM [order]
    INNER JOIN Product ON [order].ProductId = product.ProductId
    INNER JOIN Supplier ON product.SupplierId = supplier.SupplierId
    WHERE [order].IsActive = 1; 
END;
