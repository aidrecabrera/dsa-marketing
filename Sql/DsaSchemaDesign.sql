CREATE TABLE TransactionDetail
(
    TransactionId    INT PRIMARY KEY IDENTITY (1,1),
    MunicipalityName NVARCHAR(255),
    BarangayName     NVARCHAR(255)
);

CREATE TABLE TransactionDocuments
(
    DocumentId            INT PRIMARY KEY IDENTITY (1,1),
    TransactionId         INT,
    PunongBarangayName    NVARCHAR(255),
    BarangayTreasurerName NVARCHAR(255),
    FOREIGN KEY (TransactionId) REFERENCES TransactionDetail (TransactionId) ON DELETE CASCADE
);

CREATE TABLE PurchaseRequest
(
    RequestId               INT PRIMARY KEY IDENTITY (1,1),
    DocumentId              INT,
    RequestNumber           NVARCHAR(255),
    RequestDate             DATETIME,
    Requisition             NVARCHAR(255),
    DeliveryLocation        NVARCHAR(255),
    DeliveryTerms           NVARCHAR(255),
    DeliveryDate            DATETIME,
    Purpose                 NVARCHAR(255),
    RequestedByName         NVARCHAR(255),
    ApprovedForIssuanceName NVARCHAR(255),
    RequestorName           NVARCHAR(255),
    FOREIGN KEY (DocumentId) REFERENCES TransactionDocuments (DocumentId) ON DELETE CASCADE
);

CREATE TABLE PurchaseOrder
(
    OrderId           INT PRIMARY KEY IDENTITY (1,1),
    DocumentId        INT,
    ModeOfProcurement NVARCHAR(255),
    FOREIGN KEY (DocumentId) REFERENCES TransactionDocuments (DocumentId) ON DELETE CASCADE
);

CREATE TABLE AbstractQuotation
(
    AbstractId              INT PRIMARY KEY IDENTITY (1,1),
    DocumentId              INT,
    OpenDate                DATETIME,
    OfficeLocation          NVARCHAR(255),
    OfficeOfThe             NVARCHAR(255),
    AwardedToThe            NVARCHAR(255),
    OpeningQuotationsOffice NVARCHAR(255),
    FOREIGN KEY (DocumentId) REFERENCES TransactionDocuments (DocumentId) ON DELETE CASCADE
);

CREATE TABLE TransactionItems
(
    ItemId      INT PRIMARY KEY IDENTITY (1,1),
    DocumentId  INT,
    UnitName    NVARCHAR(255),
    Particulars NVARCHAR(255),
    Quantity    INT,
    Cost        DECIMAL(10, 2),
    Amount      DECIMAL(10, 2),
    Price       DECIMAL(10, 2),
    FOREIGN KEY (DocumentId) REFERENCES TransactionDocuments (DocumentId) ON DELETE CASCADE
);
