-- Database creation script for eCommerce application
CREATE DATABASE IF NOT EXISTS ecommercedb;
USE ecommercedb;

-- Categories table
CREATE TABLE IF NOT EXISTS Categories (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(500)
);

-- Users table
CREATE TABLE IF NOT EXISTS Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(50) DEFAULT 'User',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    LastLogin DATETIME NULL
);

-- Products table
CREATE TABLE IF NOT EXISTS Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(500),
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT DEFAULT 0,
    CategoryId INT NOT NULL,
    ImageUrl VARCHAR(255),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Sample data for testing
INSERT INTO Categories (Name, Description) VALUES 
('Electronics', 'Electronic devices and gadgets'),
('Clothing', 'Fashion items and apparel'),
('Books', 'Books and publications');

-- Default admin user (password: admin123)
INSERT INTO Users (Name, Email, PasswordHash, Role, CreatedAt) VALUES 
('Admin User', 'admin@example.com', '$2a$11$ckFDCzSG7tXuMYpbSaYYPOHVu8Tkg4vC3/DTi.I2rjcJH5dRcMSZu', 'Admin', NOW());
