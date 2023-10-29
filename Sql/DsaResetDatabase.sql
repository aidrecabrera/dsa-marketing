-- Delete data from all tables
DELETE FROM TransactionItems;
DELETE FROM AbstractQuotation;
DELETE FROM PurchaseOrder;
DELETE FROM PurchaseRequest;
DELETE FROM TransactionDocuments;
DELETE FROM TransactionDetail;

-- Reset primary key identities
DBCC CHECKIDENT ('TransactionItems', RESEED, 0);
DBCC CHECKIDENT ('AbstractQuotation', RESEED, 0);
DBCC CHECKIDENT ('PurchaseOrder', RESEED, 0);
DBCC CHECKIDENT ('PurchaseRequest', RESEED, 0);
DBCC CHECKIDENT ('TransactionDocuments', RESEED, 0);
DBCC CHECKIDENT ('TransactionDetail', RESEED, 0);