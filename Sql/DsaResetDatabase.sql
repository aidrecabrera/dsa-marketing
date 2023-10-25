-- Delete data from all tables
DELETE FROM TransactionItems;
DELETE FROM AbstractQuotation;
DELETE FROM PurchaseOrder;
DELETE FROM PurchaseRequest;
DELETE FROM TransactionDocuments;
DELETE FROM Transactions;

-- Reset primary key identities and start from 2023
DBCC CHECKIDENT ('TransactionItems', RESEED, 2023);
DBCC CHECKIDENT ('AbstractQuotation', RESEED, 2023);
DBCC CHECKIDENT ('PurchaseOrder', RESEED, 2023);
DBCC CHECKIDENT ('PurchaseRequest', RESEED, 2023);
DBCC CHECKIDENT ('TransactionDocuments', RESEED, 2023);
DBCC CHECKIDENT ('Transactions', RESEED, 2023);
