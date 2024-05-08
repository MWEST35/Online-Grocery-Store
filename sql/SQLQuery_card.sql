USE Project_grocery;

CREATE TABLE Card (
    Name VARCHAR(50),
    cardNumber VARCHAR(16) PRIMARY KEY,
    cvv INT,
    expDate DATE,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)

);

insert into Card (Name, cardNumber, cvv, expDate, user_id) values ('Spongebob Jr', '1234567890123456', 123, '2026-12-31', 1);
insert into Card (Name, cardNumber, cvv, expDate, user_id) values ('amazing spiderman', '1234567890123457', 123, '2026-12-31', 2);
insert into Card (Name, cardNumber, cvv, expDate, user_id) values ('kevinhart Comedian', '1234567890123458', 123, '2026-12-31', 3);
insert into Card (Name, cardNumber, cvv, expDate, user_id) values ('ironman Robert', '1234567890123459', 123, '2026-12-31', 4);
insert into Card (Name, cardNumber, cvv, expDate, user_id) values ('gunslinger gamer', '1234567890123460', 123, '2026-12-31', 5);