
USE RestaurantReservationCore;

SELECT * FROM [dbo].[Restaurants];
INSERT INTO [dbo].[Restaurants] VALUES('KFC','Nablus','0599777888','8:00AM-12:00PM');
INSERT INTO [dbo].[Restaurants] VALUES('BreakTime','Nablus','059943218','9:00AM-1:00PM');
INSERT INTO [dbo].[Restaurants] VALUES('Verona','Nablus','0599731888','10:00AM-12:00PM');
INSERT INTO [dbo].[Restaurants] VALUES('Kefaak','Nablus','0595774888','6:00AM-10:00PM');
INSERT INTO [dbo].[Restaurants] VALUES('PopEyes','Nablus','0599727128','11:00AM-9:00PM');


SELECT * FROM [dbo].[Customers];
INSERT INTO [dbo].[Customers] VALUES('Amr','AbdulSalam','Test@gmail.com','0599112233');
INSERT INTO [dbo].[Customers] VALUES('Ahmad','Tahsen','Test1@gmail.com','0599156417');
INSERT INTO [dbo].[Customers] VALUES('Sami','Malki','Test2@gmail.com','0599795417');
INSERT INTO [dbo].[Customers] VALUES('Raks','Ljsaq','Test3@gmail.com','0599749713');
INSERT INTO [dbo].[Customers] VALUES('John','Walks','Test4@gmail.com','0598595126');


SELECT * FROM [dbo].[Tables]
INSERT INTO [dbo].[Tables] VALUES('100',1);
INSERT INTO [dbo].[Tables] VALUES('20',2);
INSERT INTO [dbo].[Tables] VALUES('90',3);
INSERT INTO [dbo].[Tables] VALUES('10',4);
INSERT INTO [dbo].[Tables] VALUES('70',5);


SELECT * FROM [dbo].[Reservations]
INSERT INTO [dbo].[Reservations] VALUES('2023-10-1','small',1,1,1);
INSERT INTO [dbo].[Reservations] VALUES('2022-9-15','Large',2,2,2);
INSERT INTO [dbo].[Reservations] VALUES('2023-11-8','XLarge',3,3,3);
INSERT INTO [dbo].[Reservations] VALUES('2015-6-4','Medium',4,4,4);
INSERT INTO [dbo].[Reservations] VALUES('2019-12-23','small',5,5,5);


SELECT * FROM [dbo].[Employees]
INSERT INTO [dbo].[Employees] VALUES('John','Walks','HR' , 1);
INSERT INTO [dbo].[Employees] VALUES('Jemmy','Jans','CEO' , 2);
INSERT INTO [dbo].[Employees] VALUES('Ahmad','Wazde','MANAGER' , 3);
INSERT INTO [dbo].[Employees] VALUES('Tony','Borsa','WORKER' , 4);
INSERT INTO [dbo].[Employees] VALUES('Blosa','Hdqz','CLENER' , 5);


SELECT * FROM [dbo].[Orders]
INSERT INTO [dbo].[Orders] VALUES('2019-5-11',380.15,1,4);
INSERT INTO [dbo].[Orders] VALUES('2019-5-11',765.95,2,1);
INSERT INTO [dbo].[Orders] VALUES('2019-5-11',3741.99,3,4);
INSERT INTO [dbo].[Orders] VALUES('2019-5-11',43.72,4,4);
INSERT INTO [dbo].[Orders] VALUES('2019-5-11',998.43,5,5);


SELECT * FROM [dbo].[MenuItems]
INSERT INTO [dbo].[MenuItems] VALUES('Seafood','Salmon',15.00,1);
INSERT INTO [dbo].[MenuItems] VALUES('Burger','180g Chicken',32.7,2);
INSERT INTO [dbo].[MenuItems] VALUES('Pizza','Salmon',23.5,1);
INSERT INTO [dbo].[MenuItems] VALUES('Shawerma','Meat',12.1,3);
INSERT INTO [dbo].[MenuItems] VALUES('Burger','180g ',37.5,3);


SELECT * FROM [dbo].[OrderItems]
INSERT INTO [dbo].[OrderItems] VALUES(5,1,8);
INSERT INTO [dbo].[OrderItems] VALUES(1,2,9);
INSERT INTO [dbo].[OrderItems] VALUES(40,3,10);
INSERT INTO [dbo].[OrderItems] VALUES(23,4,11);
INSERT INTO [dbo].[OrderItems] VALUES(18,5,12);