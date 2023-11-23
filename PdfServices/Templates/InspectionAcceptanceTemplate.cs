using Aneta.Models;
using Aneta.PdfServices.Immutables;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Aneta.PdfServices.Templates;

public class InspectionAcceptanceTemplate
{
    private static DocumentParameters _documentParameters = new()
    {
        Margin = 1,
        FontSize = 10,
        Font = "Calibri",
        LineHeight = 1f,
        Border = 0.1f
    };

    public Document DsaTemplate(TransactionInfo transactionInfo, IEnumerable<TransactionItem> transactionItems)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.Letter);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(8));
                page.DefaultTextStyle(x => x.FontFamily(Fonts.Calibri));

                page.Content().Column(tableRow =>
                {
                    tableRow.Item().Element(Table).Table(header =>
                    {
                        header.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                        header.Cell().Text(text =>
                        {
                            text.AlignCenter();
                            text.Span("INSPECTION AND ACCEPTANCE REPORT").Bold().FontSize(20);
                        });
                    });

                    tableRow.Item().Element(Table).Table(main =>
                    {
                        main.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        main.Cell().Element(TableContents).Text(text =>
                        {
                            text.Span("Barangay: ").FontSize(11);
                            text.Span("\nTel No.: ").FontSize(11);
                        });
                        main.Cell().Element(TableContents).Text(text =>
                        {
                            text.Span("Municipality: ").FontSize(11);
                            text.Span("\nProvince: ").FontSize(11);
                        });
                    });

                    tableRow.Item().Element(Table).Table(main =>
                    {
                        main.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        main.Cell().Width(128.5f).BorderRight(0.5f).Element(TableContents).Text(text =>
                        {
                            text.Span("Supplier").FontSize(11);
                            text.Span("\nP.O.No.").FontSize(11);
                        });
                        main.Cell().Width(128.5f).BorderRight(0.5f).Element(TableContents).Text(text =>
                        {
                            text.Span("Invoice No.: ").FontSize(11);
                            text.Span("\nInvoice Date: ").FontSize(11);
                        });
                        main.Cell().ExtendHorizontal().BorderRight(0.5f).Element(TableContents).Text(text =>
                        {
                            text.Span("IAR No.: ").FontSize(11);
                            text.Span("\nRIS Date: ").FontSize(11);
                        });
                        main.Cell().Element(TableContents).Text(text =>
                        {
                            text.Span("Date: ").FontSize(11);
                            text.Span("\nDate: ").FontSize(11);
                        });
                    });

                    tableRow.Item().Border(0.5f).Height(370).Table(tableContainer =>
                    {
                        tableContainer.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                        tableContainer.Cell().Table(container =>
                        {
                            container.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                            container.Cell().Table(list =>
                            {
                                list.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                list.Cell().ColumnSpan(1).Element(ListTableHeader).Text(listTableHeader =>
                                {
                                    listTableHeader.Span("Unit").FontSize(11);
                                });
                                list.Cell().ColumnSpan(2).Width(273f).Element(ListTableHeader).Text(listTableHeader =>
                                {
                                    listTableHeader.Span("Description").FontSize(11);
                                });
                                list.Cell().ColumnSpan(1).BorderBottom(0.5f).Element(ListTableHeader).Text(listTableHeader =>
                                {
                                    listTableHeader.Span("Quantity").FontSize(11);
                                });
                            });

                            // List of Transaction Items
                            container.Cell().ExtendVertical().Table(list =>
                            {
                                list.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                list.Cell().ColumnSpan(1).AlignCenter().Border(0.5f).ExtendVertical().Table(qty =>
                                {
                                    qty.ColumnsDefinition(column => { column.RelativeColumn(); });
                                    qty.Cell().AlignCenter().Table(qty =>
                                    {
                                        qty.ColumnsDefinition(column => { column.RelativeColumn(); });
                                        foreach (var item in transactionItems)
                                        {
                                            qty.Cell().AlignCenter().Element(ListTableItemsCenter).Table(each =>
                                            {
                                                each.ColumnsDefinition(column => { column.RelativeColumn(); });
                                                each.Cell().AlignCenter().Text(listTableHeader =>
                                                {
                                                    listTableHeader.Span(item.UnitName).FontSize(11); // Unit
                                                });
                                            });
                                        }
                                    });
                                });
                                list.Cell().ColumnSpan(2).Width(273f).Border(0.5f).ExtendVertical().Table(qty =>
                                {
                                    qty.ColumnsDefinition(column => { column.RelativeColumn(); });
                                    qty.Cell().PaddingLeft(5).Table(qty =>
                                    {
                                        qty.ColumnsDefinition(column => { column.RelativeColumn(); });
                                        qty.Cell().Element(ListTableItemsCenter).Table(each =>
                                        {
                                            each.ColumnsDefinition(column => { column.RelativeColumn(); });
                                            foreach (var item in transactionItems)
                                            {
                                                each.Cell().Text(listTableHeader =>
                                                {
                                                    listTableHeader.Span(item.Particulars).FontSize(11); // Particulars
                                                });
                                            }
                                        });
                                    });
                                });
                                list.Cell().ColumnSpan(1).ExtendHorizontal().ExtendVertical().Table(qty =>
                                {
                                    qty.ColumnsDefinition(column => { column.RelativeColumn(); });
                                    qty.Cell().AlignCenter().Table(qty =>
                                    {
                                        qty.ColumnsDefinition(column => { column.RelativeColumn(); });
                                        qty.Cell().AlignCenter().Element(ListTableItemsCenter).Table(each =>
                                        {
                                            each.ColumnsDefinition(column => { column.RelativeColumn(); });
                                            foreach (var item in transactionItems)
                                            {
                                                each.Cell().AlignCenter().Text(listTableHeader =>
                                                {
                                                    listTableHeader.Span(item.Quantity.ToString()).FontSize(11); // Quantity
                                                });
                                            }
                                        });
                                    });
                                });
                            });
                        });
                    });

                    tableRow.Item().Table(list =>
                    {
                        list.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        list.Cell().Element(Table).Text(listTableHeader => { listTableHeader.Span("INSPECTION").FontSize(11); });
                        list.Cell().Element(Table).Text(listTableHeader => { listTableHeader.Span("ACCEPTANCE").FontSize(11); });
                    });

                    tableRow.Item().Table(list =>
                    {
                        list.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        list.Cell().Element(TableDivider).Table(column =>
                        {
                            column.ColumnsDefinition(div => { div.RelativeColumn(); });
                            column.Cell().PaddingTop(20).PaddingLeft(20).PaddingBottom(10).Text(text =>
                            {
                                text.Span("Date Inspected: ").FontSize(11);
                                text.Span("                                       ").Underline();
                            });
                            column.Cell().Padding(10).Table(box =>
                            {
                                box.ColumnsDefinition(x =>
                                {
                                    x.RelativeColumn();
                                    x.RelativeColumn();
                                });
                                box.Cell().PaddingVertical(10).PaddingHorizontal(10).Table(t =>
                                {
                                    t.ColumnsDefinition(y => { y.RelativeColumn(); });
                                    t.Cell().Border(0.5f).Height(30).Text("");
                                });
                                box.Cell().Text(text =>
                                {
                                    text.Span("Inspected, verified and found Ok as to quantity and specifications").FontSize(10);
                                });
                            });
                            column.Cell().PaddingBottom(25).PaddingTop(30).AlignCenter().Text(text =>
                            {
                                text.Span("                                       \n").Underline();
                                text.Span("Authorized Inspection").FontSize(11);
                            });
                        });
                        list.Cell().Element(TableDivider).PaddingTop(10).Table(column =>
                        {
                            column.ColumnsDefinition(div => { div.RelativeColumn(); });
                            column.Cell().PaddingTop(15).PaddingLeft(20).PaddingBottom(10).Text(text =>
                            {
                                text.Span("Date Received: ").FontSize(11);
                                text.Span("                                       ").Underline();
                            });
                            column.Cell().PaddingHorizontal(10).Table(box =>
                            {
                                box.ColumnsDefinition(x =>
                                {
                                    x.RelativeColumn();
                                    x.RelativeColumn();
                                });
                                box.Cell().PaddingVertical(10).PaddingHorizontal(10).Table(t =>
                                {
                                    t.ColumnsDefinition(y => { y.RelativeColumn(); });
                                    t.Cell().Border(0.5f).Height(30).Text("");
                                });
                                box.Cell().PaddingHorizontal(5).PaddingVertical(15).Text(text =>
                                {
                                    text.Span("Complete").FontSize(10);
                                });
                                box.Cell().PaddingHorizontal(10).Table(t =>
                                {
                                    t.ColumnsDefinition(y => { y.RelativeColumn(); });
                                    t.Cell().Border(0.5f).Height(30).Text("");
                                });
                                box.Cell().PaddingHorizontal(5).Text(text =>
                                {
                                    text.Span("Partial (Please specify quantity received)").FontSize(10);
                                });
                            });
                            column.Cell().PaddingBottom(25).PaddingTop(20).AlignCenter().Text(text =>
                            {
                                text.Span("                                       \n").Underline();
                                text.Span("SK Treasurer").FontSize(11);
                            });
                        });
                    });
                });
            });
        });
    }

    static IContainer Table(IContainer container)
    {
        return container
            .Border(0.5f)
            .PaddingHorizontal(10)
            .ShowOnce()
            .MinWidth(50)
            .MinHeight(25)
            .AlignCenter()
            .AlignMiddle();
    }

    static IContainer TableContents(IContainer container)
    {
        return container
            .Padding(5);
    }

    static IContainer ListTableHeader(IContainer container)
    {
        return container
            .BorderRight(0.5f)
            .AlignCenter()
            .PaddingVertical(5);
    }

    static IContainer ListTableItemsCenter(IContainer container)
    {
        return container
            .AlignCenter()
            .Padding(1);
    }

    static IContainer TableDivider(IContainer container)
    {
        return container
            .Border(0.5f)
            .ShowOnce()
            .MinWidth(50)
            .MinHeight(25)
            .AlignCenter()
            .AlignMiddle();
    }
}