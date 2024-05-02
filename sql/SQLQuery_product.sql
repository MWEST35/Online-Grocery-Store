USE Project_grocery;

CREATE TABLE product (
    productId INT IDENTITY(1,1) PRIMARY KEY,
    productName VARCHAR(100) NOT NULL,
    rating INT,
    category VARCHAR(50),
    dimensions VARCHAR(50),
    weight DECIMAL(10, 2),
    price DECIMAL(10, 2) NOT NULL,
    description TEXT,
    manufacturer VARCHAR(50),
    sku INT NOT NULL,
    UNIQUE(productName)
);

insert into product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku) values ('apple', 5, 'fruit', '3 x 3 x 3', 1.4, 1.00, 'fresh organic apple', 'apple inc', 1234);
insert into product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku) values ('banana', 4, 'fruit', '1 x 1.5 x 3', 0.8, 0.50, 'fresh organic banana', 'banana inc', 1235);
insert into product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku) values ('orange', 3, 'fruit', '2 x 2 x 2', 1.0, 0.75, 'fresh organic orange', 'orange inc', 1236);
insert into product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku) values ('grape', 5, 'fruit', '0.2 x 0.4 x 0.6', 0.4, 1.25, 'fresh organic grape', 'grape inc', 1237);
insert into product (productName, rating, category, dimensions, weight, price, description, manufacturer, sku) values ('strawberry', 4, 'fruit', '0.5 x 0.6 x 0.8', 0.7, 1.50, 'fresh organic strawberry', 'strawberry inc', 1238);
