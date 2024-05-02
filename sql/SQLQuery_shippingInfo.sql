USE Project_grocery;

CREATE TABLE ShippingAddress (
    address VARCHAR(255),
    state VARCHAR(50),
    city VARCHAR(50),
    zip VARCHAR(10)
);

insert into ShippingAddress (address, state, city, zip) values ('0257 Warbler Way', 'CA', 'San Francisco', '94107');
insert into ShippingAddress (address, state, city, zip) values ('534 Bunting Court', 'NY', 'New York', '10001');
insert into ShippingAddress (address, state, city, zip) values ('0 Summit Place', 'NE', 'Omaha', '68114');
insert into ShippingAddress (address, state, city, zip) values ('82025 Ridge Oak Street', 'MA', 'Boston', '02101');
insert into ShippingAddress (address, state, city, zip) values ('82025 Ridge Oak Street', 'LA', 'Los Angeles', '90001');