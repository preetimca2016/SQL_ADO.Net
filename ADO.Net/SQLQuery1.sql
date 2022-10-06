CREATE PROCEDURE sp_DeleteEmployee
@Name nvarchar(200),
@Id int
AS
DELETE AddressBookDB WHERE FirstName=@Name and EmployeeId=@Id
EXEC sp_UpdateEmployee 'Komal',2