USE Project_grocery;

CREATE TABLE Customers (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    shippingAddress VARCHAR(100) NOT NULL,
    phoneNumber VARCHAR(100) NOT NULL,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
);

insert into Customers (firstName, lastName, shippingAddress, phoneNumber, user_id) values ('Spongebob', 'Jr', '0257 Warbler Way', '138-744-5795', 1);
insert into Customers (firstName, lastName, shippingAddress, phoneNumber, user_id) values ('amazing', 'spiderman' , '534 Bunting Court', '893-268-2719', 2);
insert into Customers (firstName, lastName, shippingAddress, phoneNumber, user_id) values ('kevinhart', 'Comedian', '0 Summit Place', '389-153-7531', 3);
insert into Customers (firstName, lastName, shippingAddress, phoneNumber, user_id) values ('ironman', 'Robert', '82025 Ridge Oak Street', '525-413-8259', 4);
insert into Customers (firstName, lastName, shippingAddress, phoneNumber, user_id) values ('gunslinger', 'gamer', '82025 Ridge Oak Street', '525-413-8259', 5);

SELECT * from Customers;