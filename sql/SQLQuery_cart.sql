USE Project_grocery;

CREATE TABLE cart (
    user_id INT NOT NULL,
    cart_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (cart_id) REFERENCES cart(cart_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);

insert into cart (user_id, cart_id) values (1, 1);
insert into cart (user_id, cart_id) values (2, 2);
insert into cart (user_id, cart_id) values (3, 3);
insert into cart (user_id, cart_id) values (4, 4);
insert into cart (user_id, cart_id) values (5, 5);
