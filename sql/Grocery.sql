use grocery;

drop table Product;
drop table Cart;
drop table Card;
drop table ShippingAddress;
drop table Users;

CREATE TABLE Users (
  user_id INT IDENTITY(1,1) PRIMARY KEY,
  username VARCHAR(50) NOT NULL,
  password VARCHAR(50) NOT NULL,
  email VARCHAR(100) NOT NULL,
  phoneNumber VARCHAR(100) NOT NULL,
  name VARCHAR(100) NOT NULL,
);

insert into Users (username, password, email, phoneNumber, name) values 
  ('sponge', 'bob', 'sbob@gmail.com', '138-744-5795', 'Spongebob Jr'),
  ('spider', 'man', 'sman@gmail.com', '893-268-2719', 'amazing spiderman'),
  ('kevin', 'hart', 'khart@gmail.com', '389-153-7531', 'kevinhart'),
  ('iron', 'man', 'iman@gmail.com', '525-413-8259', 'ironman'),
  ('gun', 'slinger', 'gslinger@gmail.com', '525-413-8259', 'gunslinger gamer');

select * from Users;

CREATE TABLE ShippingAddress (
    address VARCHAR(255),
    state VARCHAR(50),
    city VARCHAR(50),
    zip VARCHAR(10),
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)

);

insert into ShippingAddress (address, state, city, zip, user_id) values 
  ('0257 Warbler Way', 'CA', 'San Francisco', '94107', 1),
  ('534 Bunting Court', 'NY', 'New York', '10001', 2),
  ('0 Summit Place', 'NE', 'Omaha', '68114', 3),
  ('82025 Ridge Oak Street', 'MA', 'Boston', '02101', 4),
  ('82025 Ridge Oak Street', 'LA', 'Los Angeles', '90001', 5);

--select * from ShippingAddress;

CREATE TABLE Card (
    Name VARCHAR(50),
    cardNumber VARCHAR(16) PRIMARY KEY,
    cvv INT,
    expDate VARCHAR(5),
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)

);

insert into Card (Name, cardNumber, cvv, expDate, user_id) values 
  ('Spongebob Jr', '1234567890123456', 123, '2026-12-31', 1),
  ('amazing spiderman', '1234567890123457', 123, '12/25', 2),
  ('kevinhart Comedian', '1234567890123458', 123, '12/25', 3),
  ('ironman Robert', '1234567890123459', 123, '12/28', 4),
  ('gunslinger gamer', '1234567890123460', 123, '12/29', 5);

--select * from Card;

CREATE TABLE Cart (
	cart_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

insert into Cart (user_id) values (1);
insert into Cart (user_id) values (2);
insert into Cart (user_id) values (3);
insert into Cart (user_id) values (4);
insert into Cart (user_id) values (5);

--select * from Cart;

CREATE TABLE Product (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    productName VARCHAR(100) NOT NULL,
    rating INT,
    category VARCHAR(50),
    dimensions VARCHAR(50),
    weight DECIMAL(10, 2),
    price DECIMAL(10, 2) NOT NULL,
    description TEXT,
    manufacturer VARCHAR(50),
    sku INT NOT NULL,
    UNIQUE(productName),
    cart_id INT,
    FOREIGN KEY (cart_id) REFERENCES cart(cart_id)

);

insert into Product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku) values 
  ('apple', 5, 'Fruit', '3 x 3 x 3', 1.4, 1.00, 'fresh organic apple', 'apple inc', 1234),
  ('banana', 4, 'Fruit', '1 x 1.5 x 3', 0.8, 0.50, 'fresh organic banana', 'banana inc', 1235),
  ('orange', 3, 'Fruit', '2 x 2 x 2', 1.0, 0.75, 'fresh organic orange', 'orange inc', 1236),
  ('grape', 5, 'Fruit', '0.2 x 0.4 x 0.6', 0.4, 1.25, 'fresh organic grape', 'grape inc', 1237),
  ('strawberry', 4, 'Fruit', '0.5 x 0.6 x 0.8', 0.7, 1.50, 'fresh organic strawberry', 'strawberry inc', 1238);

select * from Product;
