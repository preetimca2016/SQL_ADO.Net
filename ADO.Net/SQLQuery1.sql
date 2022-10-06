CREATE PROCEDURE sp_AddEmployee
@Name nvarchar(200),
@Address nvarchar(200),
@Phone bigint
AS
INSERT INTO AddressBook_DB (FirstName,Address, Phone)
								values(@Name,@Address,@Phone)
EXEC sp_AddEmployee 'ABC','GURUGRAM', 34548947