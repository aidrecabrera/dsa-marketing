CREATE TABLE Transactions (
    transaction_id INT AUTO_INCREMENT PRIMARY KEY,
    municipality_name VARCHAR(255),
    barangay_name VARCHAR(255)
);

CREATE TABLE TransactionDocuments (
    document_id INT AUTO_INCREMENT PRIMARY KEY,
    transaction_id INT,
    punong_barangay_name VARCHAR(255),
    barangay_treasurer_name VARCHAR(255),
    FOREIGN KEY (transaction_id) REFERENCES Transactions (transaction_id)
);

CREATE TABLE TransactionItems (
    item_id INT AUTO_INCREMENT PRIMARY KEY,
    document_id INT,
    unit_name VARCHAR(255),
    particulars VARCHAR(255),
    quantity INT,
    cost DECIMAL(18, 2),
    amount DECIMAL(18, 2),
    price DECIMAL(18, 2),
    FOREIGN KEY (document_id) REFERENCES TransactionDocuments (document_id)
);

CREATE TABLE PurchaseOrder (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    document_id INT,
    mode_of_procurement VARCHAR(255),
    FOREIGN KEY (document_id) REFERENCES TransactionDocuments (document_id)
);

CREATE TABLE AbstractQuotation (
    abstract_id INT AUTO_INCREMENT PRIMARY KEY,
    document_id INT,
    open_date DATE,
    office_location VARCHAR(255),
    office_of_the VARCHAR(255),
    awarded_to_the VARCHAR(255),
    opening_quotations_office VARCHAR(255),
    FOREIGN KEY (document_id) REFERENCES TransactionDocuments (document_id)
);

CREATE TABLE PurchaseRequest (
    request_id INT AUTO_INCREMENT PRIMARY KEY,
    document_id INT,
    request_number VARCHAR(255),
    request_date DATE,
    requisition VARCHAR(255),
    delivery_location VARCHAR(255),
    delivery_terms VARCHAR(255),
    delivery_date DATE,
    purpose VARCHAR(255),
    requested_by_name VARCHAR(255),
    approved_for_issuance_name VARCHAR(255),
    requestor_name VARCHAR(255),
    FOREIGN KEY (document_id) REFERENCES TransactionDocuments (document_id)
);
