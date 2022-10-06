CREATE PROCEDURE sp_UpdateEmployee
@Name nvarchar(200),
@Address nvarchar(200),
@Id int
AS
Update AddressBookDB set Address=@Address WHERE FirstName=@Name and EmployeeId=@Id
EXEC sp_UpdateEmployee 'Dhoni','GURUGRAM', 3