USE [AccreditHRSite]
GO

-- INSERT STATUS DATA
INSERT INTO Statuses (StatusDescription, IsActive)
VALUES 
	('Approved', 1),
	('Pending', 1),
	('Disabled', 1)

-- INSERT DEPARTMENT DATA
INSERT INTO Departments (DepartmentDescription, IsActive)
VALUES 
	('IT Administration', 1),
	('IT Procurement', 1),
	('IT Security', 1),
	('Network Administration', 1),
	('Systems Analysis', 1),
	('Software Development', 1),
	('Service Desk & Support', 1),
	('HR', 1),
	('Accounts', 1)

-- INSERT DUMMY EMPLOYEE DATA
INSERT INTO Employees (EmployeeNumber, Firstname, Lastname, Email, DateOfBirth, StatusID, DepartmentID, IsActive)
VALUES
    ('123450', 'EmployeeFNOne', 'EmployeeLNOne', 'Employee1@hotmail.com', '1968-01-01', 1, 1, 1),
    ('123451', 'EmployeeFNTwo', 'EmployeeLNTwo', 'Employee2@hotmail.com', '1969-02-02', 2, 2, 1),
    ('123452', 'EmployeeFNThree', 'EmployeeLNThree', 'Employee3@hotmail.com', '1970-03-03', 1, 3, 1),
    ('123453', 'EmployeeFNFour', 'EmployeeLNFour', 'Employee4@hotmail.com', '1971-04-04', 1, 4, 1),
    ('123454', 'EmployeeFNFive', 'EmployeeLNFive', 'Employee5@hotmail.com', '1972-05-05', 2, 5, 1),
    ('123455', 'EmployeeFNSix', 'EmployeeLNSix', 'Employee6hotmail.com', '1973-06-06', 1, 6, 1),
    ('123456', 'EmployeeFNSeven', 'EmployeeLNSeven', 'Employee7@hotmail.com', '1974-07-07', 3, 7, 1),
    ('123457', 'EmployeeFNEight', 'EmployeeLNEight', 'Employee8@hotmail.com', '1975-08-08', 1, 8, 1),
    ('123458', 'EmployeeFNNine', 'EmployeeLNNine', 'Employee9@hotmail.com', '1976-09-09', 1, 9, 1),
    ('123459', 'EmployeeFNTen', 'EmployeeLNTen', 'Employee10@hotmail.com', '1977-10-10', 3, 4, 1),
    ('123460', 'EmployeeFNEleven', 'EmployeeLNEleven', 'Employee11@hotmail.com', '1978-11-11', 1, 6, 1),
    ('123461', 'EmployeeFNTwelve', 'EmployeeLNTwelve', 'Employee12@hotmail.com', '1979-12-12', 1, 8, 1),
    ('123462', 'EmployeeFNThirteen', 'EmployeeLNThirteen', 'Employee13@hotmail.com', '1980-01-13', 2, 7, 1),
    ('123463', 'EmployeeFNFourteen', 'EmployeeLNFourteen', 'Employee14@hotmail.com', '1981-02-14', 1, 1, 1),
    ('123464', 'EmployeeFNFifteen', 'EmployeeLNFifteen', 'Employee15@hotmail.com', '1982-03-15', 2, 2, 1),
    ('123465', 'EmployeeFNSixteen', 'EmployeeLNSixteen', 'Employee16@hotmail.com', '1983-04-16', 1, 4, 1),
    ('123466', 'EmployeeFNSeventeen', 'EmployeeLNSeventeen', 'Employee17@hotmail.com', '1984-05-17', 2, 1, 1),
    ('123467', 'EmployeeFNEighteen', 'EmployeeLNEighteen', 'Employee18@hotmail.com', '1985-06-18', 1, 1, 1),
    ('123468', 'EmployeeFNNineteen', 'EmployeeLNNineteen', 'Employee19@hotmail.com', '1986-07-19', 1, 9, 1),
    ('123469', 'EmployeeFNTwenty', 'EmployeeLNTwenty', 'Employee20@hotmail.com', '1987-08-20', 1, 1, 1)

GO