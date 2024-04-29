USE Project_grocery;

DROP TABLE Users;

CREATE TABLE Users (
    account_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL
);

insert into Users (username, password, email) values ('sponge', 'bob', 'sbob@gmail.com');
insert into Users (username, password, email) values ('spider', 'man', 'sman@gmail.com');
insert into Users (username, password, email) values ('kevin', 'hart', 'khart@gmail.com');
insert into Users (username, password, email) values ('iron', 'man', 'iman@gmail.com');
insert into Users (username, password, email) values ('gun', 'slinger', 'gslinger@gmail.com');

SELECT * FROM Users;