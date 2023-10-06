-- Create the ALL DOCUMENTS table
CREATE TABLE TransactionDocuments (
    TID INT AUTO_INCREMENT PRIMARY KEY,
    Municipality VARCHAR(255),
    Barangay VARCHAR(255),
    `Punong Barangay` VARCHAR(255),
    `Barangay Treasurer` VARCHAR(255),
    Unit VARCHAR(255),
    Particulars VARCHAR(255),
    Quantity INT,
    Cost DECIMAL(18, 2),
    Amount DECIMAL(18, 2)
);

-- Create the Purchase Order Form table
CREATE TABLE PurchaseOrder (
    POID INT AUTO_INCREMENT PRIMARY KEY,
    TID INT,
    FOREIGN KEY (TID) REFERENCES TransactionDocuments (TID),
    `Mode of Procurement` VARCHAR(255)
);

-- Create the Abstract Quotation Form table
CREATE TABLE AbstractQuotation (
    AQID INT AUTO_INCREMENT PRIMARY KEY,
    TID INT,
    FOREIGN KEY (TID) REFERENCES TransactionDocuments (TID),
    OpenOn DATE,
    `AtTheOffice` VARCHAR(255),
    `OfficeOfThe` VARCHAR(255),
    `AwardedToThe` VARCHAR(255),
    `OfOffice` VARCHAR(255),
    `OpeningQuotationsAtTheOffice` VARCHAR(255),
    Chairman VARCHAR(255),
    `Member 1` VARCHAR(255),
    `Member 2` VARCHAR(255),
    `Member 3` VARCHAR(255),
    `Member 4` VARCHAR(255),
    `Member 5` VARCHAR(255),
    `Member 6` VARCHAR(255)abstractquotationabstractquotation
);

-- Create the Purchase Request Form table
CREATE TABLE PurchaseRequest (
    PRID INT AUTO_INCREMENT PRIMARY KEY,
    TID INT,
    FOREIGN KEY (TID) REFERENCES TransactionDocuments (TID),
    PR VARCHAR(255),
    `Date` DATE,
    REQUISITION VARCHAR(255),
    `Place of Delivery` VARCHAR(255),
    `Delivery Term` VARCHAR(255),
    `Date of Delivery` DATE,
    Purpose VARCHAR(255),
    `Requested by` VARCHAR(255),
    `Approved for Issuance` VARCHAR(255),
    Requestor VARCHAR(255)
);

-- Create the TRANSACTIONS table
CREATE TABLE Transactions (
    TID INT PRIMARY KEY,
    `City/Municipality` VARCHAR(255),
    Barangay VARCHAR(255),
    Price DECIMAL(18, 2),
    Quantity INT,
    CONSTRAINT FK_Transactions_AllDocuments FOREIGN KEY (TID) REFERENCES TransactionDocuments(TID)
);
