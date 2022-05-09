use  BookStoreDataBase

-------creating Book Table-------
create table Book(
BookId int identity(1,1) not null primary key,
BookName varchar(70) not null,
AuthorName varchar(80) not null,
Rating int ,
RatingCount int ,
DiscountPrice int,
ActualPrice int not null,
Description varchar(max) not null,
BookImage varchar(250),
BookQuantity int not null
);


select *from Book


---------Adding Book For STore Procedure------

 create proc spAddBook
(
	@BookName varchar(max),
	@AuthorName varchar(80),
	@Rating int,
	@RatingCount int,
	@DiscountPrice int,
	@ActualPrice int,
	@Description varchar(max),
	@BookImage varchar(250),
	@BookQuantity int
)
as
begin
insert into Book (BookName,AuthorName,Rating,RatingCount,DiscountPrice,ActualPrice,Description,BookImage,BookQuantity)
values(@BookName,@AuthorName,@Rating,@RatingCount,@DiscountPrice,@ActualPrice,@Description,@BookImage,@BookQuantity);
end;