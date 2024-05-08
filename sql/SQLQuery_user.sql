USE Project_grocery;


CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL
    shippingAddress VARCHAR(100) NOT NULL,
    phoneNumber VARCHAR(100) NOT NULL,
    name VARCHAR(100) NOT NULL,
);

insert into Users (username, password, email) values ('sponge', 'bob', 'sbob@gmail.com', '0257 Warbler Way', '138-744-5795', 'Spongebob Jr');
insert into Users (username, password, email) values ('spider', 'man', 'sman@gmail.com', '534 Bunting Court', '893-268-2719', 'amazing spiderman');
insert into Users (username, password, email) values ('kevin', 'hart', 'khart@gmail.com', '0 Summit Place', '389-153-7531', 'kevinhart');
insert into Users (username, password, email) values ('iron', 'man', 'iman@gmail.com', '82025 Ridge Oak Street', '525-413-8259', 'ironman');
insert into Users (username, password, email) values ('gun', 'slinger', 'gslinger@gmail.com','82025 Ridge Oak Street', '525-413-8259', 'gunslinger gamer');

SELECT * FROM Users;