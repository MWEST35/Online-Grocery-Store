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

--select * from Users;

CREATE TABLE ShippingAddress (
  shipping_id INT IDENTITY(1,1) PRIMARY KEY,
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
	card_id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    cardNumber VARCHAR(16),
    cvv INT,
    expDate VARCHAR(5),
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

insert into Card (Name, cardNumber, cvv, expDate, user_id) values 
  ('Spongebob Jr', '1234567890123456', 123, '12/26', 1),
  ('amazing spiderman', '1234567890123457', 123, '8/34', 2),
  ('kevinhart Comedian', '1234567890123458', 123, '10/28', 3),
  ('ironman Robert', '1234567890123459', 123, '10/30', 4),
  ('gunslinger gamer', '1234567890123460', 123, '7/28', 5);

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
	  imgUrl TEXT,
    cart_id INT,
    FOREIGN KEY (cart_id) REFERENCES cart(cart_id)
);

--Fruit (sku: 1#######)
insert into Product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku, imgUrl) values 
  ('Fresh Gala Apples', 3, 'Fruit', '3 x 2 x 4', 3.0, 3.86, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10000000, 'https://i5.walmartimages.com/seo/Fresh-Gala-Apples-3-lb-Bag_eebbaadc-2ca6-4e25-a2c0-c189d4871fea.bcbe9a9c422a1443b7037548bb2c54c3.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Fresh Gala Apples', 3, 'Fruit', '3 x 2 x 4', 3.0, 3.86, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10000001, 'https://i5.walmartimages.com/seo/Fresh-Gala-Apples-3-lb-Bag_eebbaadc-2ca6-4e25-a2c0-c189d4871fea.bcbe9a9c422a1443b7037548bb2c54c3.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Fresh Gala Apples', 3, 'Fruit', '3 x 2 x 4', 3.0, 3.86, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10000002, 'https://i5.walmartimages.com/seo/Fresh-Gala-Apples-3-lb-Bag_eebbaadc-2ca6-4e25-a2c0-c189d4871fea.bcbe9a9c422a1443b7037548bb2c54c3.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Fresh Honeycrisp Apples', 2, 'Fruit', '3 x 2 x 4', 3.0, 4.48, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10001000, 'https://i5.walmartimages.com/seo/Fresh-Honeycrisp-Apples-3-lb-Bag_3c15af5a-f051-40e8-a8cf-7005d68b1f68.8f7361db8c364fb7c7a367348b51d26d.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Honeycrisp Apples', 2, 'Fruit', '3 x 2 x 4', 3.0, 4.48, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10001001, 'https://i5.walmartimages.com/seo/Fresh-Honeycrisp-Apples-3-lb-Bag_3c15af5a-f051-40e8-a8cf-7005d68b1f68.8f7361db8c364fb7c7a367348b51d26d.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Honeycrisp Apples', 2, 'Fruit', '3 x 2 x 4', 3.0, 4.48, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10001002, 'https://i5.walmartimages.com/seo/Fresh-Honeycrisp-Apples-3-lb-Bag_3c15af5a-f051-40e8-a8cf-7005d68b1f68.8f7361db8c364fb7c7a367348b51d26d.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Honeycrisp Apples', 2, 'Fruit', '3 x 2 x 4', 3.0, 4.48, '3 lb bag of Fresh Organic Apples', 'Freshness Guaranteed', 10001003, 'https://i5.walmartimages.com/seo/Fresh-Honeycrisp-Apples-3-lb-Bag_3c15af5a-f051-40e8-a8cf-7005d68b1f68.8f7361db8c364fb7c7a367348b51d26d.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Bananas, Bunch', 3, 'Fruit', '2 x 2 x 3', 3.0, 2.16, 'Bundle of Fresh Bananas', 'Marketside', 10002000, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Organic-Bananas-Bunch_4b15d1c6-03e7-489b-96cb-7d4b1edeb927.042464e5bc52fa0421f255d04ec525a4.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Bananas, Bunch', 3, 'Fruit', '2 x 2 x 3', 3.0, 2.16, 'Bundle of Fresh Bananas', 'Marketside', 10002001, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Organic-Bananas-Bunch_4b15d1c6-03e7-489b-96cb-7d4b1edeb927.042464e5bc52fa0421f255d04ec525a4.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Fresh Strawberries', 2, 'Fruit', '0.5 x 0.6 x 0.8', 1.0, 2.37, '1 lb box of Fresh Strawberries', 'Fresh Produce', 10003000, 'https://i5.walmartimages.com/seo/Fresh-Strawberries-1-lb-Container_b54a64ad-e961-46cf-b60c-bc763716fb0b.a481cdfd237c5ab5438d5c9e90bead07.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Fresh Strawberries', 2, 'Fruit', '1 x 1.2 x 1.6', 2.0, 4.58, '2 lb box of Fresh Strawberries', 'Fresh Produce', 10003001, 'https://i5.walmartimages.com/seo/Fresh-Strawberries-2-lb-Container_dd2bcd97-25af-4a91-9258-989853e16b2f_1.36dd4f1579a25d423741d9970de3ddac.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF'),
  ('Fresh Strawberries', 2, 'Fruit', '1 x 1.2 x 1.6', 2.0, 4.58, '2 lb box of Fresh Strawberries', 'Fresh Produce', 10003002, 'https://i5.walmartimages.com/seo/Fresh-Strawberries-2-lb-Container_dd2bcd97-25af-4a91-9258-989853e16b2f_1.36dd4f1579a25d423741d9970de3ddac.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF');
--Vegetables (sku : 2#######)
insert into Product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku, imgUrl) values 
  ('Fresh Green Beans', 5, 'Vegetables', '3 x 2 x 4', 12.0, 2.57, '12 oz bag of Fresh Green Beans', 'New World Farms', 20000000, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Green-Beans-12-oz_103b22cf-1823-4c22-bea5-fdd627641db8.143d5bcd166225f7f545acc62faf158e.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Green Beans', 5, 'Vegetables', '3 x 2 x 4', 12.0, 2.57, '12 oz bag of Fresh Green Beans', 'New World Farms', 20000001, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Green-Beans-12-oz_103b22cf-1823-4c22-bea5-fdd627641db8.143d5bcd166225f7f545acc62faf158e.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Green Beans', 5, 'Vegetables', '3 x 2 x 4', 12.0, 2.57, '12 oz bag of Fresh Green Beans', 'New World Farms', 20000002, 'https://i5.walmartimages.com/seo/Marketside-Fresh-Green-Beans-12-oz_103b22cf-1823-4c22-bea5-fdd627641db8.143d5bcd166225f7f545acc62faf158e.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Mixed Vegetables', 3, 'Vegetables', '3 x 2 x 4', 12.0, 1.29, '12 oz bag of Frozen Mixed Vegetables', 'Great Value', 20001000, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Mixed-Vegetables-12-oz-Steamable-Bag_45e6728e-5bc6-4c0e-b10c-6f0e4d0d509a.aea17a157dad98def7d90f348814f0ec.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Mixed Vegetables', 3, 'Vegetables', '3 x 2 x 4', 12.0, 1.29, '12 oz bag of Frozen Mixed Vegetables', 'Great Value', 20001001, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Mixed-Vegetables-12-oz-Steamable-Bag_45e6728e-5bc6-4c0e-b10c-6f0e4d0d509a.aea17a157dad98def7d90f348814f0ec.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Mixed Vegetables', 3, 'Vegetables', '3 x 2 x 4', 12.0, 1.29, '12 oz bag of Frozen Mixed Vegetables', 'Great Value', 20001002, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Mixed-Vegetables-12-oz-Steamable-Bag_45e6728e-5bc6-4c0e-b10c-6f0e4d0d509a.aea17a157dad98def7d90f348814f0ec.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Mixed Vegetables', 3, 'Vegetables', '3 x 2 x 4', 12.0, 1.29, '12 oz bag of Frozen Mixed Vegetables', 'Great Value', 20001003, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Mixed-Vegetables-12-oz-Steamable-Bag_45e6728e-5bc6-4c0e-b10c-6f0e4d0d509a.aea17a157dad98def7d90f348814f0ec.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Baby-Cut Carrots', 3, 'Vegetables', '2 x 2 x 3', 2.0, 2.68, '2 lb bag of Baby-Cut Carrots', 'Fresh Produce', 20002000, 'https://i5.walmartimages.com/seo/Fresh-Baby-Cut-Carrots-2lb-Bag_7e8ec89d-158d-41d7-9dd4-aada713d1227.bda0fd4fa50396bc2205c1ca2e38ea75.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Fresh Baby-Cut Carrots', 3, 'Vegetables', '2 x 2 x 3', 2.0, 2.68, '2 lb bag of Baby-Cut Carrots', 'Fresh Produce', 20002001, 'https://i5.walmartimages.com/seo/Fresh-Baby-Cut-Carrots-2lb-Bag_7e8ec89d-158d-41d7-9dd4-aada713d1227.bda0fd4fa50396bc2205c1ca2e38ea75.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Broccoli Florets', 2, 'Vegetables', '1 x 1.2 x 1.6', 2.0, 1.16, '2 lb bag of Frozen Broccoli Florets', 'Great Value', 20003000, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Broccoli-Florets-12-oz-Steamable-Bag_c6e47501-d339-4baa-ac33-94518223ff3b.e6736cdc6c8437702d6a2f6db2d243c0.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Broccoli Florets', 2, 'Vegetables', '1 x 1.2 x 1.6', 2.0, 1.16, '2 lb bag of Frozen Broccoli Florets', 'Great Value', 20003001, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Broccoli-Florets-12-oz-Steamable-Bag_c6e47501-d339-4baa-ac33-94518223ff3b.e6736cdc6c8437702d6a2f6db2d243c0.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Frozen Broccoli Florets', 2, 'Vegetables', '1 x 1.2 x 1.6', 2.0, 1.16, '2 lb bag of Frozen Broccoli Florets', 'Great Value', 20003002, 'https://i5.walmartimages.com/seo/Great-Value-Frozen-Broccoli-Florets-12-oz-Steamable-Bag_c6e47501-d339-4baa-ac33-94518223ff3b.e6736cdc6c8437702d6a2f6db2d243c0.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF');
--Bread (sku : 3#######)
insert into Product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku, imgUrl) values 
  ('Sara Lee Honey Wheat Bread', 5, 'Bread', '3 x 2 x 4', 20.0, 3.28, '20 oz Sliced Loaf of Honey Wheat Bread', 'Sara Lee', 30000000, 'https://i5.walmartimages.com/seo/Sara-Lee-Honey-Wheat-Sandwich-Bread-20-Oz-Loaf-of-Honey-Wheat-Bread_a0d48b55-e696-45e6-9589-5ee298588c95.e087c5e51331af6cbddcefba971d3aa8.png?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Sara Lee Honey Wheat Bread', 5, 'Bread', '3 x 2 x 4', 20.0, 3.28, '20 oz Sliced Loaf of Honey Wheat Bread', 'Sara Lee', 30000001, 'https://i5.walmartimages.com/seo/Sara-Lee-Honey-Wheat-Sandwich-Bread-20-Oz-Loaf-of-Honey-Wheat-Bread_a0d48b55-e696-45e6-9589-5ee298588c95.e087c5e51331af6cbddcefba971d3aa8.png?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Wonder Bread Classic White Bread', 3, 'Bread', '3 x 2 x 4', 20.0, 2.92, '20 oz Sliced Loaf of White Bread', 'Wonder', 30001000, 'https://i5.walmartimages.com/seo/Wonder-Bread-Classic-White-Sandwich-Bread-Sliced-White-Bread-20-oz_e73bf7b6-13db-4652-b0f3-c04d23b72a90.2384b0140e2e47d942780541108b7e51.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Great Value Honey Wheat Bread', 4, 'Bread', '3 x 2 x 4', 20.0, 1.87, '20 oz Sliced Loaf of Honey Wheat Bread', 'Great Value', 30002000, 'https://i5.walmartimages.com/seo/Great-Value-Honey-Wheat-Bread-20-oz_7c8efaf7-d8ee-4d9f-b3a0-9d13d771b073.a58fb2aada5bfbead5b54dc4480cf099.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Great Value Honey Wheat Bread', 4, 'Bread', '3 x 2 x 4', 20.0, 1.87, '20 oz Sliced Loaf of Honey Wheat Bread', 'Great Value', 30002001, 'https://i5.walmartimages.com/seo/Great-Value-Honey-Wheat-Bread-20-oz_7c8efaf7-d8ee-4d9f-b3a0-9d13d771b073.a58fb2aada5bfbead5b54dc4480cf099.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Great Value White Bread', 2, 'Bread', '3 x 2 x 4', 20.0, 1.42, '20 oz Sliced Loaf of White Bread', 'Great Value', 30003000, 'https://i5.walmartimages.com/seo/Great-Value-White-Round-Top-Bread-Loaf-20-oz_8e69fca6-dda1-47b1-959c-7ec4d84b0a58.8cae75bc1ffe9c3d1ece768c0e5447a2.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF');
--Meat (sku : 4#######)
insert into Product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku, imgUrl) values 
  ('Ground Beef', 5, 'Meat', '3 x 2 x 4', 1.0, 4.62, '1 lb Roll of All Natural 73% Lean/27% Fat Ground Beef', 'Fresh Ground Beef', 40000000, 'https://i5.walmartimages.com/seo/All-Natural-73-Lean-27-Fat-Ground-Beef-1-lb-Roll_c47fd78e-029b-42a5-8005-3566f23755cc.d00e9a20eabb7e18b19ddd86af3ec83b.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Ground Beef', 5, 'Meat', '3 x 2 x 4', 1.0, 4.62, '1 lb Roll of All Natural 73% Lean/27% Fat Ground Beef', 'Fresh Ground Beef', 40000001, 'https://i5.walmartimages.com/seo/All-Natural-73-Lean-27-Fat-Ground-Beef-1-lb-Roll_c47fd78e-029b-42a5-8005-3566f23755cc.d00e9a20eabb7e18b19ddd86af3ec83b.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Ground Beef', 5, 'Meat', '3 x 2 x 4', 1.0, 4.62, '1 lb Roll of All Natural 73% Lean/27% Fat Ground Beef', 'Fresh Ground Beef', 40000002, 'https://i5.walmartimages.com/seo/All-Natural-73-Lean-27-Fat-Ground-Beef-1-lb-Roll_c47fd78e-029b-42a5-8005-3566f23755cc.d00e9a20eabb7e18b19ddd86af3ec83b.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Ball Park Beef Hot Dogs', 4, 'Meat', '3 x 2 x 4', 15.0, 4.84, '15 oz Pack of Beef Hot Dogs (8 Count)', 'Ball Park', 40002000, 'https://i5.walmartimages.com/seo/Ball-Park-Beef-Hot-Dogs-15-oz-8-Count_cf4c5e24-14ef-4da2-a283-ce93cc40329b.57181ce6f671bfe8fe240b70935621e2.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF'),
  ('Ball Park Beef Hot Dogs', 4, 'Meat', '3 x 2 x 4', 15.0, 4.84, '15 oz Pack of Beef Hot Dogs (8 Count)', 'Ball Park', 40002001, 'https://i5.walmartimages.com/seo/Ball-Park-Beef-Hot-Dogs-15-oz-8-Count_cf4c5e24-14ef-4da2-a283-ce93cc40329b.57181ce6f671bfe8fe240b70935621e2.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF'),
  ('Chicken Breast Tenderloins', 2, 'Meat', '3 x 2 x 4', 3.0, 9.93, '3 lb Tray of Sliced Chicken Breast Tenderloins', 'Freshness Guaranteed', 40003000, 'https://i5.walmartimages.com/seo/Freshness-Guaranteed-Chicken-Breast-Tenderloins-2-25-3-2-lb-Tray_71631179-1a59-455d-8c15-becbc2dc9ee7.4e8693b1f8abc387ebe752031f49bf72.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Chicken Breast Tenderloins', 2, 'Meat', '3 x 2 x 4', 3.0, 9.93, '3 lb Tray of Sliced Chicken Breast Tenderloins', 'Freshness Guaranteed', 40003001, 'https://i5.walmartimages.com/seo/Freshness-Guaranteed-Chicken-Breast-Tenderloins-2-25-3-2-lb-Tray_71631179-1a59-455d-8c15-becbc2dc9ee7.4e8693b1f8abc387ebe752031f49bf72.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Chicken Breast Tenderloins', 2, 'Meat', '3 x 2 x 4', 3.0, 9.93, '3 lb Tray of Sliced Chicken Breast Tenderloins', 'Freshness Guaranteed', 40003002, 'https://i5.walmartimages.com/seo/Freshness-Guaranteed-Chicken-Breast-Tenderloins-2-25-3-2-lb-Tray_71631179-1a59-455d-8c15-becbc2dc9ee7.4e8693b1f8abc387ebe752031f49bf72.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF'),
  ('Chicken Breast Tenderloins', 2, 'Meat', '3 x 2 x 4', 3.0, 9.93, '3 lb Tray of Sliced Chicken Breast Tenderloins', 'Freshness Guaranteed', 40003003, 'https://i5.walmartimages.com/seo/Freshness-Guaranteed-Chicken-Breast-Tenderloins-2-25-3-2-lb-Tray_71631179-1a59-455d-8c15-becbc2dc9ee7.4e8693b1f8abc387ebe752031f49bf72.jpeg?odnHeight=160&odnWidth=160&odnBg=FFFFFF');

--select * from Product;
