use projectShop;

/*Account and user tables*/

create table Customer
(
cus_id int IDENTITY(1,1),
cus_fn varchar(30),
cus_lf varchar(30),
cus_mail varchar(30),
cus_phone int,
 
primary key(cus_id)
);

DBCC CHECKIDENT ('[Customer]', RESEED, 0)

GO

create table Account
(
acc_id int IDENTITY(1,1),
act_code int,
acc_name varchar(50),
acc_pass varchar(50),

primary key(acc_id)
);

DBCC CHECKIDENT ('[Account]', RESEED, 0)

GO

create table Account_Info
(
id int IDENTITY(1,1),
acc_id int,
acc_zipcode int,
acc_city varchar(50),
foreign key(acc_id) references Account(acc_id) on delete cascade,
primary key(id)
);

DBCC CHECKIDENT ('[Account_Info]', RESEED, 0)

GO



create table Account_Role
(
id int IDENTITY(1,1),
role_id int,
role_acc int,
foreign key(role_id) references Account(acc_id) on delete cascade,
primary key(id)
);

DBCC CHECKIDENT ('[Account_Role]', RESEED, 0)

GO


create table Role
(
id int IDENTITY(1,1),
role_id int,
role_type varchar(30),
foreign key(role_id) references Account_Role(id) on delete cascade,
primary key(id)
);

DBCC CHECKIDENT ('[Role]', RESEED, 0)

GO




create table Activation
(
act_id int IDENTITY (1,1),
act_code int,
primary key(act_id)
);

DBCC CHECKIDENT ('[Activation]', RESEED, 0)

GO





/*Orders, Product, brand, categories*/

create table Product_Item
(
listitem_id int IDENTITY(1,1),
listitem_instock int,

primary key(listitem_id)
);

DBCC CHECKIDENT ('[Product_Item]', RESEED, 0)

GO



create table Product_Image
(
image_id int IDENTITY(1,1),
listitem_id int,
image_name varchar(30),
image_alt varchar(30),
image_text varchar(30),
foreign key(listitem_id) references Product_Item(listitem_id) on delete cascade,
primary key(image_id)
);


DBCC CHECKIDENT ('[Product_Image]', RESEED, 0)

GO


create table Product
(
id int IDENTITY(1,1),
product_id int ,
product_name varchar(50),
product_price int,
product_description varchar(100),
foreign key(product_id) references Product_Item(listitem_id) on delete cascade,
primary key(id)
);

DBCC CHECKIDENT ('[Product]', RESEED, 0)

GO


create table Category
(
category_id int IDENTITY(1,1),
category_name varchar(50),
primary key(category_id)
);

DBCC CHECKIDENT ('[Category]', RESEED, 0)

GO


create table Brand
(
brand_id int IDENTITY(1,1),
brand_name varchar(100),
primary key(brand_id)
);

DBCC CHECKIDENT ('[Brand]', RESEED, 0)

GO

create table Category_Brand
(

categorybrand_id int IDENTITY (1,1),
categorybrand_category int,
foreign key(categorybrand_category) references Category(category_id) on delete cascade,
foreign key(categorybrand_category) references Brand(brand_id) on delete cascade,

primary key(categorybrand_id)

);

DBCC CHECKIDENT ('[Category_Brand]', RESEED, 0)

GO



create table Product_Catogory
(
id int IDENTITY(1,1),
productcategory_id int,
productcategory_category int,
foreign key(productcategory_category) references Category(category_id) on delete cascade,
foreign key(productcategory_id) references Product(id) on delete cascade,
primary key(id)

);

DBCC CHECKIDENT ('[Product_Catogory]', RESEED, 0)

GO





