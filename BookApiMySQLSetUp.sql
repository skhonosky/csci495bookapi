CREATE DATABASE Books;
USE Books;
CREATE USER 'csci495bookuser'@'localhost' IDENTIFIED BY 'csci495bookpass';
GRANT ALL PRIVILEGES ON *.* TO 'csci495bookuser'@'localhost' WITH GRANT OPTION;

DROP TABLE IF EXISTS Books;

CREATE TABLE Books (
 Title VARCHAR(100), 
 ReleaseYear int, 
 Author VARCHAR(100), 
 Genre VARCHAR(50),
 PRIMARY KEY (Title)
 );
 
INSERT INTO Books VALUES ("Fault in Our Stars", 2012, "John Green", "Romance");
INSERT INTO Books VALUES ("Turtle All The Way Down", 2017, "John Green", "Young Adult");
INSERT INTO Books VALUES ("Paper Towns", 2008, "John Green", "Romance");
INSERT INTO Books VALUES ("The Paris Apartment", 2022, "Lucy Foley", "Mystery");
INSERT INTO Books VALUES ("Verity", 2018, "Colleen Hoover", "Thriller");
INSERT INTO Books VALUES ("It Starts With Us", 2022, "Colleen Hoover", "Romance");

Select * From Books;