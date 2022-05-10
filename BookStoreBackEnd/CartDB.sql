use  BookStoreDataBase
--cReating Cart TAble-----

create table CartsTable
(
	CartId int identity(1,1) not null primary key,
	OrderQuantity int default 1,
	UserId int foreign key references UsersRegistration(UserId) on delete no action,
	BookId int foreign key references Book(BookId) on delete no action
);
select * from CartsTable

-----Adding  to Cart Stored Procedure-----

create proc spAddBookToCart
(
@OrderQuantity int,
@UserId int,
@BookId int
)
as
begin 
		if(exists(select * from Book where BookId=@BookId))
		begin
		insert into CartsTable(OrderQuantity,UserId,BookId)
		values(@OrderQuantity,@UserId,@BookId)
		end
		else
		begin
		select 1
		end
end;

------GetCart bY USErid Stored Procedure-----

create proc spGetCartByUserId
(
	@UserId int
)
as
begin
	select CartId,OrderQuantity,UserId,c.BookId,BookName,AuthorName,
	DiscountPrice,ActualPrice,BookImage from Carts c join Book b on c.BookId=b.BookId 
	where UserId=@UserId;
end;
