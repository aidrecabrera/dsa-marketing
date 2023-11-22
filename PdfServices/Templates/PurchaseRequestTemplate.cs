using Aneta.Models;
using Aneta.PdfServices.Immutables;
using Humanizer;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Aneta.PdfServices.Templates;

public class PurchaseRequestTemplate
{
    public Document DsaTemplate(TransactionInfo transactionInfo, IEnumerable<TransactionItem> transactionItems)
    {
        return Document.Create(container =>
        {
            float BorderWidth = 0.5f;
            float FontSize = 10;
            float FontSizeTitle = 25;
            float LineHeight = 1.2f;
            float LetterSpacing = 0.001f;
            float Margin = 1;
            float totalCost = 0.00f;
            container.Page(page =>
            {
                page.Size(PageSizes.Letter);
                page.Margin(Margin, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(FontSize));
                page.DefaultTextStyle(x => x.FontFamily(Fonts.Calibri));

                page.Content().Column(tableRow =>
                {
                    tableRow.Item().Table(header =>
                    {
                        header.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                        header.Cell()
                            .Border(BorderWidth)
                            .Text(text =>
                            {
                                text.AlignCenter();
                                text.Span("PURCHASE REQUEST")
                                    .Bold()
                                    .FontSize(FontSizeTitle);
                            });
                    });
                    tableRow.Item().Border(BorderWidth).Table(content =>
                    {
                        content.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        content.Cell().BorderRight(BorderWidth).Padding(5).Text(text =>
                        {
                            text.Span("Barangay: ")
                                .FontSize(FontSize);
                            text.Span(transactionInfo.Barangay)
                                .FontSize(FontSize);
                            text.Span("\nCity/Municipality: ")
                                .FontSize(FontSize);
                            text.Span(transactionInfo.Municipality)
                                .FontSize(FontSize);
                        });
                        content.Cell().Padding(5).Text(text =>
                        {
                            text.Span("PR: ")
                                .FontSize(FontSize);
                            text.Span(transactionInfo.Pr)
                                .FontSize(FontSize);
                            text.Span("\nDate: ")
                                .FontSize(FontSize);
                            text.Span("")
                                .FontSize(FontSize);
                        });
                    });
                    tableRow.Item().Border(BorderWidth).Table(content =>
                    {
                        content.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        content.Cell().ColumnSpan(2).PaddingVertical(10).AlignCenter().Text(text =>
                        {
                            text.Span("REQUSITION")
                                .Bold()
                                .FontSize(15);
                        });
                    });
                    tableRow.Item().Border(BorderWidth).Table(content =>
                    {
                        content.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        content.Cell().ColumnSpan(2).Padding(5).Text(text =>
                        {
                            text.Span(
                                    "Gentlemen\n                  Please deliver this office the following articles subject to the terms and conditions contained herein.")
                                .FontSize(FontSize);
                        });
                    });
                    tableRow.Item().Table(content =>
                    {
                        content.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        content.Cell().Border(BorderWidth).Table(tableRow =>
                        {
                            tableRow.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                            tableRow.Cell().Padding(5).Text(text =>
                            {
                                text.Span("Place of Delivery: ")
                                    .FontSize(FontSize);
                                text.Span(transactionInfo.DeliveryPlace)
                                    .FontSize(FontSize);
                                text.Span("\nDate of Delivery: ")
                                    .FontSize(FontSize);
                                text.Span(transactionInfo.DeliveryDate)
                                    .FontSize(FontSize);
                            });
                        });
                        content.Cell().Border(BorderWidth).Table(tableRow =>
                        {
                            tableRow.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                            tableRow.Cell().Padding(5).Text(text =>
                            {
                                text.Span("Delivery Term: ")
                                    .FontSize(FontSize);
                                text.Span(transactionInfo.TermDelivery)
                                    .FontSize(FontSize);
                                text.Span("\nPayment Term: ")
                                    .FontSize(FontSize);
                                text.Span(transactionInfo.TermPayment)
                                    .FontSize(FontSize);
                            });
                        });
                    });
                    tableRow.Item().Border(BorderWidth).Table(itemList =>
                    {
                        itemList.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        itemList.Cell().ColumnSpan(1).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                element.Cell().AlignCenter().AlignMiddle().Padding(5).Text("Item No.").FontSize(10);
                            });
                        });
                        itemList.Cell().ColumnSpan(1).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                element.Cell().AlignCenter().AlignMiddle().Padding(5).Text("Qty.").FontSize(10);
                            });
                        });
                        itemList.Cell().ColumnSpan(1).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                element.Cell().AlignCenter().AlignMiddle().Padding(5).Text("Unit of Issue")
                                    .FontSize(10);
                            });
                        });
                        itemList.Cell().ColumnSpan(4).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                element.Cell().AlignCenter().AlignMiddle().Padding(5).Text("Item Description")
                                    .FontSize(10);
                            });
                        });
                        itemList.Cell().ColumnSpan(1).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                element.Cell().AlignCenter().AlignMiddle().Padding(5).Text("Estimated Unit Cost")
                                    .FontSize(10);
                            });
                        });
                        itemList.Cell().ColumnSpan(2).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                element.Cell().AlignCenter().AlignMiddle().Padding(5).Text("Estimated Amount")
                                    .FontSize(10);
                            });
                        });
                    });
                    tableRow.Item().Height(350).Border(BorderWidth).Table(itemList =>
                    {
                        itemList.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        itemList.Cell().ColumnSpan(1).Height(350).BorderRight(BorderWidth).Table(column =>
                        {
                            // For Item List Iteration
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                foreach (var i in transactionItems)
                                {
                                    element.Cell().Padding(5).Text("").FontSize(10);
                                }
                            });
                        });
                        itemList.Cell().ColumnSpan(1).Height(350).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                foreach (var i in transactionItems)
                                {
                                    element.Cell().Padding(5).Text(i.Quantity).FontSize(10);
                                }
                            });
                        });
                        itemList.Cell().ColumnSpan(1).Height(350).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                foreach (var i in transactionItems)
                                {
                                    element.Cell().Padding(5).Text(i.UnitName).FontSize(10);
                                }
                            });
                        });
                        itemList.Cell().ColumnSpan(4).Height(350).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                foreach (var i in transactionItems)
                                {
                                    element.Cell().Padding(5).Text(i.Particulars).FontSize(10);
                                }
                            });
                        });
                        itemList.Cell().ColumnSpan(1).Height(350).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                foreach (var i in transactionItems)
                                {
                                    element.Cell().Padding(5).Text(i.Cost).FontSize(10);
                                }
                            });
                        });
                        itemList.Cell().ColumnSpan(2).Height(350).BorderRight(BorderWidth).Table(column =>
                        {
                            column.ColumnsDefinition(column => { column.RelativeColumn(); });
                            column.Cell().Table(element =>
                            {
                                element.ColumnsDefinition(column => { column.RelativeColumn(); });
                                foreach (var i in transactionItems)
                                {
                                    element.Cell().Padding(5).Text(i.Amount).FontSize(10);
                                    totalCost += (float)i.Amount;
                                }
                            });
                        });
                    });
                    tableRow.Item().Border(BorderWidth).Table(row =>
                    {
                        row.ColumnsDefinition(column => { column.RelativeColumn(); });
                        row.Cell().Padding(5).Text(text =>
                        {
                            int humanizedCost = (int)totalCost;
                            text.Span("(TOTAL ESTIMATED AMOUNT) ")
                                .Italic()
                                .FontSize(FontSize);
                            text.Span(humanizedCost.ToWords().Transform(To.UpperCase));
                        });
                    });
                    tableRow.Item().Border(BorderWidth).Table(row =>
                    {
                        row.ColumnsDefinition(column => { column.RelativeColumn(); });
                        row.Cell().Padding(5).Text(text =>
                        {
                            text.Span("Purpose: ")
                                .FontSize(FontSize);
                        });
                    });
                    tableRow.Item().ExtendVertical().Border(BorderWidth).Table(row =>
                    {
                        row.ColumnsDefinition(column =>
                        {
                            column.RelativeColumn();
                            column.RelativeColumn();
                        });
                        row.Cell().Column(1).ExtendVertical().BorderRight(BorderWidth).Padding(5).Table(table =>
                        {
                            table.ColumnsDefinition(column => { column.RelativeColumn(); });
                            table.Cell().Text(text =>
                            {
                                text.Span("Requested by: ")
                                    .FontSize(FontSize);
                            });
                            table.Cell().Row(2).AlignCenter().Text(text =>
                            {
                                text.Span("\n" + transactionInfo.Requestor)
                                    .Bold()
                                    .FontSize(FontSize);
                            });
                            table.Cell().Row(2).AlignCenter().Text(text =>
                            {
                                text.Span("\n_______________________")
                                    .FontSize(FontSize);
                            });
                            table.Cell().AlignCenter().Text(text =>
                            {
                                text.Span("Signature over Printed Name of the Requestor")
                                    .FontSize(FontSize);
                            });
                            table.Cell().AlignCenter().Text(text =>
                            {
                                text.Span("DATE: _____________")
                                    .FontSize(FontSize);
                            });
                        });
                        row.Cell().Column(2).ExtendVertical().Padding(5).Table(table =>
                        {
                            table.ColumnsDefinition(column => { column.RelativeColumn(); });
                            table.Cell().Text(text =>
                            {
                                text.Span("Approved for Issuance: ")
                                    .FontSize(FontSize);
                            });
                            table.Cell().Row(2).AlignCenter().Text(text =>
                            {
                                text.Span("\n" + transactionInfo.PunongBarangay)
                                    .Bold()
                                    .FontSize(FontSize);
                            });
                            table.Cell().Row(2).AlignCenter().Text(text =>
                            {
                                text.Span("\n_______________________")
                                    .FontSize(FontSize);
                            });
                            table.Cell().AlignCenter().Text(text =>
                            {
                                text.Span("SK CHAIRMAN")
                                    .FontSize(FontSize);
                            });
                            table.Cell().AlignCenter().Text(text =>
                            {
                                text.Span("DATE: _____________")
                                    .FontSize(FontSize);
                            });
                        });
                    });
                });
            });
        });
    }
}