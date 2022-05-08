create database BookStoreDataBase

use BookStoreDataBase

-----create table for user----

create table UsersRegistration(
UserId int identity(1,1)not null primary key,
FullName varchar(max) not null,
Email varchar(max) not null,
Password varchar(max) not null,
MobileNumber varchar(20) not null
);


select * from UsersRegistration
-----creating store procedure for user table----

create or alter Proc spRegisterUser
(
    @FullName Varchar(Max),
    @Email varchar(Max),
    @Password varchar(Max),
    @MobileNumber varchar(30) 
)
as
begin
        Insert Into UsersRegistration (FullName, Email, Password, MobileNumber)
        Values (@FullName, @Email, @Password, @MobileNumber);
        
End;

------User Login Stored Procedure-------
create Proc spUserLogin
(
    @Email varchar(Max),
    @Password varchar(Max)
)
as
begin
    select * from UsersRegistration
    where
        Email=@Email
        and
        Password=@Password
end;

create or alter proc spUserForgotPassword
(
	@Email varchar(Max)
)
as
begin
	update UsersRegistration
	set 
		Password ='Null'
	where 
		Email = @Email;
    select * from UsersRegistration where Email = @Email;
end;

create proc spUserResetPassword
(
	@Email varchar(Max),
	@Password varchar(Max)
)
AS
BEGIN
	update UsersRegistration 
	SET 
		Password = @Password 
	where
		Email = @Email;
end;