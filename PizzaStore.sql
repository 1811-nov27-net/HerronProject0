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
	FavoriteStoreID int,

	constraint PS_Customer_ID primary key (CustomerID)
);

-- drop table PS.CustomerAddressLookup


create table PS.CustomerAddressLookup
(
	CustomerID int not null,
	CustomerAddressID int not null
);


-- drop table PS.Store

create table PS.Store
(
	StoreID int identity not null,
	StoreAddressID int not null,
	constraint PS_Store_ID primary key (StoreID)
);


-- drop table PS.Invantory

create table PS.Invantory
(
	StoreID int not null,
	IngrediantID int not null,
	Quantity int not null
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

-- drop table PS.PizzasInOrder

create table PS.PizzasInOrder
(
	PizzaID int not null,
	PizzaOrderID int not null,
	Quantity int not null
);


-- drop table PS.Pizza

create table PS.Pizza
(
	PizzaID int identity not null,
	Size int not null,
	Cost money not null,
	constraint PS_Pizza_ID primary key (PizzaID)
);

-- drop table PS.IngrediantList

create table PS.IngrediantList
(
	IngrediantID int identity not null,
	IngrediantName nvarchar(100),
	constraint PS_Ingrediant_ID primary key (IngrediantID)
);

-- drop table PS.IngrediantsOnPizza

create table PS.IngrediantsOnPizza
(
	PizzaID int not null,
	IngrediantID int not null,
);