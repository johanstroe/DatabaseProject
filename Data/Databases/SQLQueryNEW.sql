INSERT INTO Customers (Name) VALUES
( 'Tech Solutions AB'),
( 'Green Energy Corp'),
( 'FastTrack Logistics');

INSERT INTO Employees(FirstName, LastName, Email) VALUES
( 'Alice', 'Andersson', 'alice.andersson@example.com'),
( 'Bob', 'Bergström', 'bob.bergstrom@example.com'),
( 'Charlie', 'Carlsson', 'charlie.carlsson@example.com');

INSERT INTO Products (ProductName, Price) VALUES
( 'Webbplattform Licens', 4999.99),
( 'Solpanel Modell X', 12999.50),
( 'Transportoptimering Software', 8999.00);

INSERT INTO Statuses (StatusName) VALUES ('Pågående'), ('Avslutat'), ('Ej påbörjat');

INSERT INTO Projects (ProjectName, StatusId, StartDate, EndDate, CustomerId, EmployeeId, ProductId) VALUES
( 'Webbplattform Utveckling', 1, '2024-01-15', '2024-06-30', 1, 1, 1),
( 'Solpanel Implementation', 2, '2024-03-01', '2024-12-01', 2, 2, 2),
( 'Transportoptimering', 3, '2023-05-10', '2023-12-20', 3, 3, 3);


DBCC CHECKIDENT ('Statuses', RESEED, 0);