USE Project_grocery;

CREATE TABLE product (
    productId INT IDENTITY(1,1) PRIMARY KEY,
    productName VARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    description TEXT,
    manufacturer VARCHAR(50),
    sku INT NOT NULL,
    UNIQUE(productName)
);

insert into product (productName, price, description, manufacturer, sku) values ('apple', 1.00, 'fresh organic apple', 'apple inc', 1234);
insert into product (productName, price, description, manufacturer, sku) values ('banana', 0.50, 'fresh organic banana', 'banana inc', 1235);
insert into product (productName, price, description, manufacturer, sku) values ('orange', 0.75, 'fresh organic orange', 'orange inc', 1236);
insert into product (productName, price, description, manufacturer, sku) values ('grape', 1.25, 'fresh organic grape', 'grape inc', 1237);
insert into product (productName, price, description, manufacturer, sku) values ('strawberry', 1.50, 'fresh organic strawberry', 'strawberry inc', 1238);