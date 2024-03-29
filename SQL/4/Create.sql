CREATE DATABASE Bank;

USE Bank;

CREATE TABLE Person
(
	Id VARCHAR(11) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Surname VARCHAR(50) NOT NULL
);

CREATE TABLE Phone
(
	Id INT PRIMARY KEY,
	PersonId VARCHAR(11) NOT NULL FOREIGN KEY REFERENCES Person(Id),
	Country VARCHAR(3) NOT NULL,
	Phone VARCHAR(20) NOT NULL
);

CREATE TABLE BankAccount
(
	Id INT PRIMARY KEY,
	PersonId VARCHAR(11) NOT NULL FOREIGN KEY REFERENCES Person(Id),
	Balance DECIMAL NOT NULL DEFAULT 0,
);

CREATE TABLE BankCard
(
	Id INT PRIMARY KEY,
	AccountId INT FOREIGN KEY REFERENCES BankAccount(Id),
	Number VARCHAR(16) NOT NULL,
	CVC VARCHAR(3) NOT NULL,
	Exp DATE NOT NULL
);
