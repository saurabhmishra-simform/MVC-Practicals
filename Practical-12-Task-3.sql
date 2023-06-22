CREATE TABLE Designation
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    DesignationName VARCHAR(50) NOT NULL
);

INSERT INTO Designation (DesignationName) VALUES ('Manager');
INSERT INTO Designation (DesignationName) VALUES ('Java Developer');
INSERT INTO Designation (DesignationName) VALUES ('DotNet Developer');
INSERT INTO Designation (DesignationName) VALUES ('UI/UX');
INSERT INTO Designation (DesignationName) VALUES ('Python Developer');


CREATE TABLE EmployeeTaskThree
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    MobileNumber NVARCHAR(10) NOT NULL,
    Address NVARCHAR(50) NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    DesignationId INT,
    FOREIGN KEY (DesignationId) REFERENCES Designation (Id)
);


INSERT INTO EmployeeTaskThree (FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary, DesignationId)
VALUES
    ('John', 'A', 'Doe', '1990-01-01', '1234567890', '123 Street', 5000.00, 1),
    ('Jane', 'B', 'Smith', '1992-02-02', '9876543210', '456 Avenue', 6000.00, 2),
    ('Michael', 'C', 'Johnson', '1994-03-03', '5555555555', '789 Road', 7000.00, 3),
    ('Sarah', 'D', 'Williams', '1996-04-04', '1111111111', '321 Lane', 8000.00, 1),
    ('David', 'E', 'Brown', '1998-05-05', '9999999999', '654 Boulevard', 9000.00, 2),
    ('Emily', 'F', 'Jones', '2000-06-06', '4444444444', '987 Drive', 10000.00, 3),
    ('Matthew', 'G', 'Davis', '2002-07-07', '2222222222', '123 Street', 11000.00, 1),
    ('Olivia', 'H', 'Miller', '2004-08-08', '7777777777', '456 Avenue', 12000.00, 2),
    ('Daniel', 'I', 'Wilson', '2006-09-09', '3333333333', '789 Road', 13000.00, 3),
    ('Sophia', 'J', 'Taylor', '2008-10-10', '8888888888', '321 Lane', 14000.00, 1);

select * from EmployeeTaskThree;
select * from Designation;

--Write a query to count the number of records by designation name
SELECT D.DesignationName, COUNT(E.Id) AS EmployeeCount
FROM EmployeeTaskThree E
INNER JOIN Designation D ON E.DesignationId = D.Id
GROUP BY D.DesignationName;

--Create a database view that outputs Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary
CREATE VIEW EmployeeView AS
SELECT
    E.Id AS EmployeeId,
    E.FirstName,
    E.MiddleName,
    E.LastName,
    D.DesignationName AS Designation,
    E.DOB,
    E.MobileNumber,
    E.Address,
    E.Salary
FROM
    EmployeeTaskThree E
    INNER JOIN Designation D ON E.DesignationId = D.Id;

Select * from EmployeeView;

--Create a stored procedure to insert data into the Designation table with required parameters
CREATE PROCEDURE InsertIntoDesignation
    @DesignationName VARCHAR(50)
AS
BEGIN
    INSERT INTO Designation (DesignationName)
    VALUES (@DesignationName)
END

EXEC InsertIntoDesignation @DesignationName = 'Team Lead';

--Create a stored procedure to insert data into the Employee table with required parameters
CREATE PROCEDURE InsertIntoEmployee
    @FirstName VARCHAR(50),
    @MiddleName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DesignationId INT,
    @DOB DATE,
    @MobileNumber NVARCHAR(10),
    @Address NVARCHAR(50),
    @Salary DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Employee VALUES (@FirstName, @MiddleName, @LastName, @DesignationId, @DOB, @MobileNumber, @Address, @Salary)
END

EXEC InsertIntoEmployee
    @FirstName = 'John',
    @MiddleName = 'A',
    @LastName = 'Doe',
    @DesignationId = 1,
    @DOB = '1990-01-01',
    @MobileNumber = '1234567890',
    @Address = '123 Street',
    @Salary = 5000.00;

--Write a query that displays only those designation names that have more than 1 employee
SELECT D.DesignationName
FROM Designation D
INNER JOIN EmployeeTaskThree E ON D.Id = E.DesignationId
GROUP BY D.DesignationName
HAVING COUNT(*) > 1;

--Create a stored procedure that returns a list of employees with columns Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary (records should be ordered by DOB)
CREATE PROCEDURE GetEmployeesOrderByDOB
AS
BEGIN
    SELECT E.Id AS EmployeeId, E.FirstName, E.MiddleName, E.LastName, D.DesignationName AS Designation,
           E.DOB, E.MobileNumber, E.Address, E.Salary
    FROM EmployeeTaskThree E
    INNER JOIN Designation D ON E.DesignationId = D.Id
    ORDER BY E.DOB;
END

GetEmployeesOrderByDOB;

--Create a stored procedure that return a list of employees by designation id (Input) with columns Employee Id, First Name, Middle Name, Last Name, DOB, Mobile Number, Address & Salary (records should be ordered by First Name)
CREATE PROCEDURE GetEmployeesByDesignationId
    @DesignationId INT
AS
BEGIN
    SELECT E.Id AS EmployeeId, E.FirstName, E.MiddleName, E.LastName,
           E.DOB, E.MobileNumber, E.Address, E.Salary
    FROM EmployeeTaskThree E
    WHERE E.DesignationId = @DesignationId
    ORDER BY E.FirstName;
END

GetEmployeesByDesignationId 1;

--Create Non-Clustered index on the DesignationId column of the Employee table
CREATE NONCLUSTERED INDEX IX_Employee_DesignationId
ON EmployeeTaskThree (DesignationId);

--Write a query to find the employee having maximum salary
SELECT TOP 1 E.Id AS EmployeeId, E.FirstName, E.MiddleName, E.LastName,
              E.DOB, E.MobileNumber, E.Address, E.Salary
FROM EmployeeTaskThree E
ORDER BY E.Salary DESC;