USE Project_grocery;

CREATE TABLE cart (
    user_id INT NOT NULL,
    cartId INT IDENTITY(1,1) PRIMARY KEY,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES product(productId)
);

insert into cart (user_id, cartId) values (1, 1);
insert into cart (user_id, cartId) values (2, 2);
insert into cart (user_id, cartId) values (3, 3);
insert into cart (user_id, cartId) values (4, 4);
insert into cart (user_id, cartId) values (5, 5);
