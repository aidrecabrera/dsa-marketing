CREATE VIEW TransactionSummary AS
SELECT
    t.TransactionId AS TransactionId,
    t.MunicipalityName AS MunicipalityName,
    t.BarangayName AS BarangayName,
    ti.ItemId AS ItemId,
    ti.DocumentId AS ItemDocumentId,
    ti.UnitName AS UnitName,
    ti.Particulars AS Particulars,
    ti.Quantity AS Quantity,
    ti.Amount AS ItemAmount,
    ti.Price AS ItemPrice,
    td.TransactionId AS TransactionDocumentId,
    td.PunongBarangayName AS PunongBarangayName,
    td.BarangayTreasurerName AS BarangayTreasurerName,
    td.DocumentId AS DocumentId,
    pr.RequestId AS RequestId,
    pr.DocumentId AS RequestDocumentId,
    pr.RequestNumber AS RequestNumber,
    pr.Requisition AS Requisition,
    pr.DeliveryLocation AS DeliveryLocation,
    pr.RequestDate AS RequestDate,
    pr.DeliveryTerms AS DeliveryTerms,
    pr.DeliveryDate AS DeliveryDate,
    pr.RequestedByName AS RequestedByName,
    pr.ApprovedForIssuanceName AS ApprovedForIssuanceName,
    pr.Purpose AS Purpose,
    pr.RequestorName AS RequestorName,
    po.DocumentId AS PurchaseOrderDocumentId,
    po.ModeOfProcurement AS ModeOfProcurement,
    po.OrderId AS OrderId,
    aq.AbstractId AS AbstractId,
    aq.DocumentId AS AbstractDocumentId,
    aq.OpenDate AS AbstractOpenDate,
    aq.OfficeLocation AS AbstractOfficeLocation,
    aq.OfficeOfThe AS OfficeOfThe,
    aq.AwardedToThe AS AwardedToThe,
    aq.OpeningQuotationsOffice AS OpeningQuotationsOffice,
    ti.Cost AS ItemCost
FROM
    dbo.AbstractQuotation AS aq
        INNER JOIN
    dbo.TransactionDocuments AS td ON aq.DocumentId = td.DocumentId
        INNER JOIN
    dbo.PurchaseOrder AS po ON td.DocumentId = po.DocumentId
        INNER JOIN
    dbo.PurchaseRequest AS pr ON td.DocumentId = pr.DocumentId
        INNER JOIN
    dbo.TransactionItems AS ti ON td.DocumentId = ti.DocumentId
        INNER JOIN
    dbo.TransactionDetail AS t ON td.TransactionId = t.TransactionId;
