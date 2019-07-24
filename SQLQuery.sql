USE [customers]

CREATE TABLE [dbo].[Customers](
	[ID] [decimal](10, 0) NOT NULL,
	[Name] [varchar](30) NULL,
	[Email] [varchar](25) NULL,
	[MobileNo] [decimal](10, 0) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Transactions](
	[ID] [decimal](18, 0) NOT NULL,
	[Datetime] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[Status] [nchar](10) NOT NULL,
	[CustomerID] [decimal](10, 0) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_CustomerTransaction] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([ID])

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_CustomerTransaction]

INSERT INTO Customers (ID, Name, Email, MobileNo) VALUES (1, 'User1', 'my@email.com', 0751258896)
INSERT INTO Customers (ID, Name, Email, MobileNo) VALUES (2, 'User2', 'my@email.com', 0751258896)
INSERT INTO Customers (ID, Name, Email, MobileNo) VALUES (3, 'User3', 'my@email.com', 0751258896)
INSERT INTO Customers (ID, Name, Email, MobileNo) VALUES (4, 'User4', 'my@email.com', 0751258896)
INSERT INTO Customers (ID, Name, Email, MobileNo) VALUES (5, 'User5', 'my@email.com', 0751258896)
INSERT INTO Customers (ID, Name, Email, MobileNo) VALUES (6, 'User5', 'my6@email.com', 0751258896)

INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (1, GETDATE(), 100.00, 'USD', 'Success', 1)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (2, GETDATE(), 100.00, 'USD', 'Success', 1)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (3, GETDATE(), 100.00, 'USD', 'Success', 1)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (4, GETDATE(), 100.00, 'USD', 'Success', 1)

INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (5, GETDATE(), 100.00, 'USD', 'Success', 2)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (6, GETDATE(), 100.00, 'USD', 'Success', 2)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (7, GETDATE(), 100.00, 'USD', 'Success', 2)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (8, GETDATE(), 100.00, 'USD', 'Success', 2)

INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (9, GETDATE(), 100.00, 'USD', 'Success', 6)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (10, GETDATE(), 100.00, 'USD', 'Success', 6)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (11, GETDATE(), 100.00, 'USD', 'Success', 6)
INSERT INTO Transactions (ID, Datetime, Amount, Currency, Status, CustomerID) VALUES (12, GETDATE(), 100.00, 'USD', 'Success', 6)