USE Project_grocery;

CREATE TABLE cart (
    user_id INT NOT NULL,
    cartId INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT,
    product_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES product(productId)
);

insert into cart (user_id, quantity, product_id) values (1, 2, 1);
insert into cart (user_id, quantity, product_id) values (2, 1, 2), (3, 1, 3), (1, 1, 4);
insert into cart (user_id, quantity, product_id) values (2, 1, 5), (3, 1, 4), (1, 1, 3), (2, 1, 1);
insert into cart (user_id, quantity, product_id) values (3, 1, 2), (1, 1, 5), (2, 1, 3), (3, 1, 1);
insert into cart (user_id, quantity, product_id) values (1, 1, 2), (2, 1, 4), (3, 1, 5), (1, 1, 1), (2, 1, 2);
