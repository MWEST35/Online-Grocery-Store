USE Project_grocery;

CREATE TABLE cart (
    user_id INT NOT NULL,
    cartId INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

insert into cart (user_id, quantity) values (1, 1), (2, 2), (3, 3), (4, 4), (5, 5);
insert into cart (user_id, quantity) values (2, 2);
insert into cart (user_id, quantity) values (3, 3), (4, 4);
insert into cart (user_id, quantity) values (5, 5), (1, 1);
