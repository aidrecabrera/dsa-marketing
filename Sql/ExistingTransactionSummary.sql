CREATE VIEW ExistingTransactionSummary AS
SELECT
    t.TransactionId AS TransactionId,
    t.MunicipalityName AS MunicipalityName,
    t.BarangayName AS BarangayName,
    td.TransactionId AS TransactionDocumentId,
    td.PunongBarangayName AS PunongBarangayName,
    td.BarangayTreasurerName AS BarangayTreasurerName,
    td.DocumentId AS DocumentId
FROM
    dbo.TransactionDetail AS t
        INNER JOIN
    dbo.TransactionDocuments AS td ON t.TransactionId = td.TransactionId;
