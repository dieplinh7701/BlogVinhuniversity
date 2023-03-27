CREATE DATABASE TinTucDaiHocVinh;

Use TinTucDaiHocVinh

CREATE TABLE Banner(
	BannerId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Title nvarchar(max) NOT NULL,
    Description nvarchar(max) NOT NULL,
    Image nvarchar(500),
)
CREATE TABLE BlogNews (
    BlogId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	CategoryId Int,
	Image nvarchar(500) ,
	Title nvarchar(max) NOT NULL,
	Description nvarchar(500) NOT NULL,
	Content nvarchar(max) NOT NULL,
	ModifiedBy datetime NOT NULL,
	IsNew bit NOT NULL,
	Highlights bit NOT NULL,
	FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
)
CREATE TABLE Category (
    CategoryId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Title nvarchar(250) NOT NULL,
    Image nvarchar(500) NOT NULL,
    KeyWord nvarchar(500) NOT NULL,
)

CREATE TABLE Contact (
    ContactId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Name nvarchar(150) NOT NULL,
	Email nvarchar(100) NOT NULL,
    Description nvarchar(500) NOT NULL,
	ModifiedBy datetime NOT NULL
)
CREATE TABLE Review(
    ReviewId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Title nvarchar(100) NOT NULL,
    Description nvarchar(500) NOT NULL,
    Detail nvarchar(500) NOT NULL,
    Image nvarchar(500),
	ModifiedBy datetime
)
CREATE TABLE Users (
    UserId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    UserName nvarchar(100) NOT NULL,
    Password nvarchar(100) NOT NULL,
    FirstName nvarchar(20) NOT NULL,
    LastName nvarchar(20) NOT NULL,
    AddRess nvarchar(100) NOT NULL,
	PhoneNumber int NOT NULL,
)