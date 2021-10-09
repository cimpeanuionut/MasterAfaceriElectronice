IF (DB_ID(N'MagazinVirtual') IS NULL)
	CREATE DATABASE MagazinVirtual
GO

USE MagazinVirtual
GO

IF OBJECT_ID ('Roles') IS NULL
	CREATE TABLE Roles
	(
	Id INT NOT NULL CONSTRAINT PK_Role PRIMARY KEY,
	RoleName NVARCHAR(255) NOT NULL,	
	)
GO

IF OBJECT_ID ('Users') IS NULL
	CREATE TABLE Users
	(
	Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_UserId DEFAULT NEWID(),
	UserName NVARCHAR(256) NOT NULL CONSTRAINT UK_UserName UNIQUE,
	[Password] NVARCHAR(256) NOT NULL,
	LastLogin DATETIME NULL,
	IsActiv BIT NOT NULL CONSTRAINT DF_IsActiv DEFAULT 1,
	RoleId INT NOT NULL,
	SurName NVARCHAR(256) NOT NULL,
	[Name] NVARCHAR(256) NOT NULL,
	Email NVARCHAR(500) NOT NULL,
	PhoneNumber NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY (Id)
	)
GO

IF OBJECT_ID ('ProductTypes') IS NULL
	CREATE TABLE ProductTypes
	(
	Id INT NOT NULL IDENTITY (1, 1) CONSTRAINT PK_ProductType PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL
	)
GO

IF OBJECT_ID ('SpecialTags') IS NULL
	CREATE TABLE SpecialTags
	(
	Id INT NOT NULL IDENTITY (1, 1) CONSTRAINT PK_SpecialTag PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL
	)
GO

IF OBJECT_ID ('Products') IS NULL
	CREATE TABLE Products
	(
	Id INT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_Product PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[Description] NVARCHAR(2000) NOT NULL, 
	Price NUMERIC(20, 2) NOT NULL,
	IsAvailable BIT NOT NULL,
	ImagePath NVARCHAR(1000) NULL,
	ProductTypeId INT NOT NULL
	)
GO

IF OBJECT_ID ('ProductsSpecialTags') IS NULL
	CREATE TABLE ProductsSpecialTags
	(
	SpecialTagId INT NOT NULL,
	ProductId INT NOT NULL,
	CONSTRAINT PK_ProductSpecialTag PRIMARY KEY (SpecialTagId, ProductId)
	)
GO

IF OBJECT_ID ('Feedback') IS NULL 
	CREATE TABLE Feedback
	(
	Id INT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_Feedback PRIMARY KEY,
	CommentTitle NVARCHAR(256) NOT NULL,
	Comment NVARCHAR(2000) NOT NULL,
	Rating INT NOT NULL,
	ProductId INT NOT NULL,
	UserId UNIQUEIDENTIFIER NULL
	)
GO

IF OBJECT_ID('Orders') IS NULL
	CREATE TABLE Orders
	(
	Id INT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_Orders PRIMARY KEY,
	CustomerName NVARCHAR(256) NOT NULL,
	CustomerPhoneNumber NVARCHAR(256) NOT NULL,
	CustomerEmail NVARCHAR(256) NOT NULL,
	CustomerAddress NVARCHAR(500) NOT NULL,
	OrderDate DATETIME NOT NULL
	)
GO

IF OBJECT_ID('OrdersProducts') IS NULL
	CREATE TABLE OrdersProducts
	(
	ProductId INT NOT NULL,
	OrderId INT NOT NULL,
	CONSTRAINT PK_OrdersProducts PRIMARY KEY (ProductId, OrderId)
	)
GO

IF OBJECT_ID('USP_CreateFK') IS NOT NULL
	DROP PROCEDURE USP_CreateFK
GO

CREATE PROCEDURE USP_CreateFK
@FKName NVARCHAR(512),
@ChildTableName NVARCHAR(256),
@ChildColumnName NVARCHAR(256),
@ParentTableName NVARCHAR(256),
@ParentColumnName NVARCHAR(256),
@CascadeDelete BIT = 0
AS
BEGIN
	DECLARE @sql NVARCHAR(4000)
	SET @sql =  'IF (OBJECT_ID(''' + @FKName +''', ''F'') IS NULL)' +
				'ALTER TABLE ' + @ChildTableName + ' ' +
				'ADD CONSTRAINT ' + @FKName + ' ' +
				'FOREIGN KEY (' + @ChildColumnName + ')' +
				'REFERENCES ' + @ParentTableName + '(' + @ParentColumnName + ')'
	IF (@CascadeDelete = 1)
		SET @sql = @sql + 'ON DELETE CASCADE '
    EXEC sp_executesql @sql
END
GO

EXEC USP_CreateFK 'FK_Users_Roles', 'Users', 'RoleId', 'Roles', 'Id'
GO

EXEC USP_CreateFK 'FK_Products_ProductTypes', 'Products', 'ProductTypeId', 'ProductTypes', 'Id'
GO

EXEC USP_CreateFK 'FK_ProductsSpecialTags_SpecialTags', 'ProductsSpecialTags', 'SpecialTagId', 'SpecialTags', 'Id'
GO

EXEC USP_CreateFK 'FK_ProductsSpecialTags_Products', 'ProductsSpecialTags', 'ProductId', 'Products', 'Id', 1
GO

EXEC USP_CreateFK 'FK_Feedback_Products', 'Feedback', 'ProductId', 'Products', 'Id'
GO

EXEC USP_CreateFK 'FK_Feedback_Users', 'Feedback', 'UserId', 'Users', 'Id'
GO

EXEC USP_CreateFK 'FK_OrdersProducts_Orders', 'OrdersProducts', 'OrderId', 'Orders', 'Id', 1
GO

EXEC USP_CreateFK 'FK_OrdersProducts_Products', 'OrdersProducts', 'ProductId', 'Products', 'Id'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 1)
INSERT INTO Roles (Id, RoleName)
SELECT 1, 'SuperAdmin'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 2)
INSERT INTO Roles (Id, RoleName)
SELECT 2, 'Admin'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 3)
INSERT INTO Roles (Id, RoleName)
SELECT 3, 'Director'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 4)
INSERT INTO Roles (Id, RoleName)
SELECT 4, 'SalesManager'
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 5)
INSERT INTO Roles (Id, RoleName)
SELECT 5, 'SalesAgent'
GO

DECLARE @UserId UNIQUEIDENTIFIER = '414D6C6F-4E20-46F7-848F-D3FCF0AF2A05'
IF NOT EXISTS (SELECT 1 FROM Users WHERE Id = @UserId)
INSERT INTO Users(Id, UserName, [Password], RoleId, SurName, [Name], Email, PhoneNumber)
SELECT @UserId, 'Admin', 'YWRtaW4=', 1, 'Admin', 'Admin', 'admin@app.com', '0723045984'
GO