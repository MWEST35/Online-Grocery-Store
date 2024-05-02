USE Project_grocery;

CREATE TABLE Card (
    Name VARCHAR(50),
    cardNumber VARCHAR(16) PRIMARY KEY,
    cvv INT,
    expDate DATE
);

insert into Card (Name, cardNumber, cvv, expDate) values ('Spongebob Jr', '1234567890123456', 123, '2026-12-31');
insert into Card (Name, cardNumber, cvv, expDate) values ('amazing spiderman', '1234567890123457', 123, '2026-12-31');
insert into Card (Name, cardNumber, cvv, expDate) values ('kevinhart Comedian', '1234567890123458', 123, '2026-12-31');
insert into Card (Name, cardNumber, cvv, expDate) values ('ironman Robert', '1234567890123459', 123, '2026-12-31');
insert into Card (Name, cardNumber, cvv, expDate) values ('gunslinger gamer', '1234567890123460', 123, '2026-12-31');