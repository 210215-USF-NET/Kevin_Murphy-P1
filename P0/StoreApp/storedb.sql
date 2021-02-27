--clear DB
drop table orderItems;
drop table inventories;
drop table products;
drop table storeOrders;
drop table locations;
drop table customers;
drop table carTypes;


-- create tables

create table carTypes
(
	id int identity primary key,
	carType varChar(30) not null
);

create table customers
(
	id int identity primary key,
	customerName varchar(100)not null,
	phoneNumber varchar(13) not null,
	carType int references carTypes(id)
);

create table locations
(
	id int identity primary key,
	locationName varchar(20),
	locationAddress varchar(30)
);

create table inventories
(
	id int identity primary key,
	inventoryName varchar(20) not null,
	quantity int not null,
	location int references locations(id),
	product int references products(id)
);

create table storeOrders
(
	id int identity primary key,
	total float not null,
	customer int references customers(id),
	location int references locations(id)
);

create table products
(
	id int identity primary key,
	productName varchar(20) not null,
	productDescription varchar(100) not null,
	productPrice float not null
);

create table orderItems
(
	id int identity primary key,
	quantity int not null,
	storeOrder int references storeorders(id),
	product int references products(id)
);

--seed the DB

insert into carTypes(carType)values
('Truck'),('Coup'),('Sedan'),('SUV');

insert into customers(customerName,phoneNumber,carType)values
('Kevin','(111)111-1111',1);


insert into products(productName,productDescription,productPrice)values
('Bumper','This goes on your car',15),('Head lights','They help you see in the dark',45);
insert into locations(locationName,locationAddress)values
('Online store','www.store.com');

insert into storeOrders(total,customer,location)values
(30.00,2,1);

insert into orderItems(quantity,storeOrder,product)values
(2,3,1);

insert into inventorys(inventoryName,quantity,location,product)values
('Online Inventory',2,1,1);

-- select * from inventories;
-- select * from customers;
-- select * from carTypes;
-- select * from storeOrders;
-- select * from locations;