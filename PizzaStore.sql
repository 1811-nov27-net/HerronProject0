-- initialization commands for Pizza Store App database

create database PizzaStoreDB;

go

create schema PS -- PS stands for Pizza Store

go


-- drop table PS.StoreAddress

create table PS.StoreAddress
(
	StoreAddressID int identity not null,
	Street nvarchar(100) not null,
	Street2 nvarchar(100) null,
	City nvarchar(100) not null,
	Zip int not null,
	State nvarchar(100) not null,
	StoreID int not null, -- ID of store
	constraint PS_StoreAddress_ID primary key (StoreAddressID)
);

-- drop table PS.CustomerAddress

create table PS.CustomerAddress
(
	CustomerAddressID int identity not null,
	Street nvarchar(100) not null,
	Street2 nvarchar(100) null,
	City nvarchar(100) not null,
	Zip int not null,
	State nvarchar(100) not null,
	CustomerID int not null, -- ID of store
	constraint PS_CustomerAddress_ID primary key (CustomerAddressID)
);

-- drop table PS.Customer

create table PS.Customer
(
	CustomerID int identity not null,
	Username nvarchar(100) not null,
	Password nvarchar(100) not null,
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	CustomerAddressID int not null,
	FavoriteStore int,

	constraint PS_Customer_ID primary key (CustomerID)
);

-- drop table PS.Store

create table PS.Store
(
	StoreID int identity not null,
	StoreAddressID int not null,
	Sausage int,
	Peperoni int,
	[Black Olives] int,
	[Green Olives] int,
	[Bell Peppers] int,
	[Jalapenos] int,
	Chicken int,
	[Hot Sauce] int,
	Mushrooms int,
	Pineapple int,
	Onions int,
	Tomatoes int,
	[Extra Cheese] int,

	constraint PS_Store_ID primary key (StoreID)
);

-- drop table PS.PizzaOrder

create table PS.PizzaOrder
(
	PizzaOrderID int identity not null,
	StoreID int not null,
	CustomerID int not null,
	TotalDue money not null,
	DatePlaced datetime2 not null,
	constraint PS_PizzaOrder_ID primary key (PizzaOrderID)
);

-- drop table PS.Order


create table PS.Pizza
(
	PizzaID int identity not null,
	PizzaOrderID int not null,
	Size int not null,
	Sausage bit,
	Peperoni bit,
	[Black Olives] bit,
	[Green Olives] bit,
	[Bell Peppers] bit,
	[Jalapenos] bit,
	Chicken bit,
	[Hot Sauce] bit,
	Mushrooms bit,
	Pineapple bit,
	Onions bit,
	Tomatoes bit,
	[Extra Cheese] bit,
	constraint PS_Pizza_ID primary key (PizzaID)
);

