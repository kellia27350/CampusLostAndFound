

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CampusLostAndFound')
BEGIN
    CREATE DATABASE CampusLostAndFound;
END
GO

USE CampusLostAndFound;
GO

-- =====================================================
-- Table: Users
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId       INT IDENTITY(1,1) PRIMARY KEY,
        FullName     NVARCHAR(150)  NOT NULL,
        Email        NVARCHAR(255)  NOT NULL UNIQUE,
        StudentId    NVARCHAR(50)   NOT NULL,
        PasswordHash NVARCHAR(500)  NOT NULL,
        Role         NVARCHAR(20)   NOT NULL DEFAULT 'Student',  -- 'Student' | 'Admin'
        CreatedAt    DATETIME       NOT NULL DEFAULT GETDATE()
    );
END
GO

-- =====================================================
-- Table: Categories
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories')
BEGIN
    CREATE TABLE Categories (
        CategoryId   INT IDENTITY(1,1) PRIMARY KEY,
        CategoryName NVARCHAR(100) NOT NULL UNIQUE
    );
END
GO

-- Seed default categories
IF NOT EXISTS (SELECT 1 FROM Categories)
BEGIN
    INSERT INTO Categories (CategoryName) VALUES
        ('Electronics'),
        ('Books'),
        ('Bags'),
        ('Keys'),
        ('Documents'),
        ('Clothing'),
        ('Jewelry'),
        ('Sports Equipment'),
        ('Other');
END
GO

-- =====================================================
-- Table: Items
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Items')
BEGIN
    CREATE TABLE Items (
        ItemId       INT IDENTITY(1,1) PRIMARY KEY,
        UserId       INT            NOT NULL,
        CategoryId   INT            NOT NULL,
        ItemName     NVARCHAR(200)  NOT NULL,
        Description  NVARCHAR(1000) NOT NULL,
        Location     NVARCHAR(300)  NOT NULL,
        ReportDate   DATE           NOT NULL,
        ReportType   NVARCHAR(10)   NOT NULL,  -- 'Lost' | 'Found'
        ImagePath    NVARCHAR(500)  NULL,
        Status       NVARCHAR(20)   NOT NULL DEFAULT 'Active',  -- 'Active' | 'Returned'
        CreatedAt    DATETIME       NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Items_Users      FOREIGN KEY (UserId)     REFERENCES Users(UserId),
        CONSTRAINT FK_Items_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
    );
END
GO

-- =====================================================
-- Table: Claims
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Claims')
BEGIN
    CREATE TABLE Claims (
        ClaimId     INT IDENTITY(1,1) PRIMARY KEY,
        ItemId      INT            NOT NULL,
        UserId      INT            NOT NULL,
        Explanation NVARCHAR(1000) NOT NULL,
        ClaimDate   DATETIME       NOT NULL DEFAULT GETDATE(),
        ClaimStatus NVARCHAR(20)   NOT NULL DEFAULT 'Pending',  -- 'Pending' | 'Reviewed' | 'Accepted' | 'Rejected'
        CONSTRAINT FK_Claims_Items FOREIGN KEY (ItemId) REFERENCES Items(ItemId),
        CONSTRAINT FK_Claims_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
    );
END
GO

-- =====================================================
-- Default Admin account  (password: Admin@123)
-- Hash is SHA-256 of "Admin@123" base64-encoded
-- The app uses BCrypt-style salted hash; replace after first run
-- =====================================================
IF NOT EXISTS (SELECT 1 FROM Users WHERE Role = 'Admin')
BEGIN
    -- Placeholder hash; the application will accept login only after
    -- you change the password through the app or update this hash.
    -- Use the app's Register flow with Role = Admin set manually,
    -- or run the app once and let AccountController seed the admin.
    INSERT INTO Users (FullName, Email, StudentId, PasswordHash, Role)
    VALUES ('Administrator', 'admin@campus.ac.rw', 'ADMIN001',
            -- BCrypt hash of "Admin@123" (cost 12) – pre-generated
            '$2a$12$KIx3mT9dL6vE2nQpW8zRbOy5uJhF4cGsA1mD7eNvX0wKlP3qYtZri', 'Admin');
END
GO

PRINT 'Database setup complete.';
GO
