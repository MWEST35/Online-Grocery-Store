USE Project_grocery;

CREATE TABLE ShippingAddress (
    address VARCHAR(255),
    state VARCHAR(50),
    city VARCHAR(50),
    zip VARCHAR(10),
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)

);

insert into ShippingAddress (address, state, city, zip, user_id) values ('0257 Warbler Way', 'CA', 'San Francisco', '94107', 1);
insert into ShippingAddress (address, state, city, zip, user_id) values ('534 Bunting Court', 'NY', 'New York', '10001', 2);
insert into ShippingAddress (address, state, city, zip, user_id) values ('0 Summit Place', 'NE', 'Omaha', '68114', 3);
insert into ShippingAddress (address, state, city, zip, user_id) values ('82025 Ridge Oak Street', 'MA', 'Boston', '02101', 4);
insert into ShippingAddress (address, state, city, zip, user_id) values ('82025 Ridge Oak Street', 'LA', 'Los Angeles', '90001', 5);