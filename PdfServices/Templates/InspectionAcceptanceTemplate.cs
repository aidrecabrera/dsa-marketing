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
                page.DefaultTextStyle(x => x.FontSize(10));
                page.DefaultTextStyle(x => x.FontFamily(Fonts.Calibri));

                page.Content().Column(tableRow =>
                {
                    tableRow.Item().Element(Table).Table(header =>
                    {
                        header.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                        header.Cell().Text(text =>
                        {
                            text.AlignCenter();
                            text.Span("INSPECTION AND ACCEPTANCE REPORT").Bold().FontSize(25);
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
                            text.Span("Barangay: ");
                            text.Span("\nTel No.: ");
                        });
                        main.Cell().Element(TableContents).Text(text =>
                        {
                            text.Span("Municipality: ");
                            text.Span("\nProvince: ");
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
                        main.Cell().BorderRight(0.5f).Element(TableContents).Text(text =>
                        {
                            text.Span("Supplier");
                            text.Span("\nP.O.No.");
                        });
                        main.Cell().BorderRight(0.5f).Element(TableContents).Text(text =>
                        {
                            text.Span("Invoice No.: ");
                            text.Span("\nInvoice Date: ");
                        });
                        main.Cell().BorderRight(0.5f).Element(TableContents).Text(text =>
                        {
                            text.Span("IAR No.: ");
                            text.Span("\nRIS Date: ");
                        });
                        main.Cell().Element(TableContents).Text(text =>
                        {
                            text.Span("Date: ");
                            text.Span("\nDate: ");
                        });
                    });

                    tableRow.Item().Table(list =>
                    {
                        list.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        list.Cell().Element(ListTableHeader).Text(listTableHeader => { listTableHeader.Span("Unit"); });
                        list.Cell().Element(ListTableHeader).Text(listTableHeader =>
                        {
                            listTableHeader.Span("Description");
                        });
                        list.Cell().Element(ListTableHeader).Text(listTableHeader =>
                        {
                            listTableHeader.Span("Quantity");
                        });
                    });

                    // List of Transaction Items
                    tableRow.Item().Table(list =>
                    {
                        list.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        list.Cell().Element(ListTableItemsCenter).Text(listTableHeader =>
                        {
                            listTableHeader.Span("");
                        });
                        list.Cell().Element(ListTableItemsLeft).Text(listTableHeader => { listTableHeader.Span(""); });
                        list.Cell().Element(ListTableItemsCenter).Text(listTableHeader =>
                        {
                            listTableHeader.Span("");
                        });
                    });

                    tableRow.Item().Table(list =>
                    {
                        list.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        list.Cell().Element(Table).Text(listTableHeader => { listTableHeader.Span("INSPECTION"); });
                        list.Cell().Element(Table).Text(listTableHeader => { listTableHeader.Span("ACCEPTANCE"); });
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
                                text.Span("Date Inspected: ");
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
                                    text.Span("Inspected, verified and found Ok as to quantity and specifications");
                                });
                            });
                            column.Cell().PaddingBottom(25).PaddingTop(30).AlignCenter().Text(text =>
                            {
                                text.Span("                                       \n").Underline();
                                text.Span("Authorized Inspection");
                            });
                        });
                        list.Cell().Element(TableDivider).PaddingTop(10).Table(column =>
                        {
                            column.ColumnsDefinition(div => { div.RelativeColumn(); });
                            column.Cell().PaddingTop(15).PaddingLeft(20).PaddingBottom(10).Text(text =>
                            {
                                text.Span("Date Received: ");
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
                                    text.Span("Complete");
                                });
                                box.Cell().PaddingHorizontal(10).Table(t =>
                                {
                                    t.ColumnsDefinition(y => { y.RelativeColumn(); });
                                    t.Cell().Border(0.5f).Height(30).Text("");
                                });
                                box.Cell().PaddingHorizontal(5).Text(text =>
                                {
                                    text.Span("Partial (Please specify quantity received)");
                                });
                            });
                            column.Cell().PaddingBottom(25).PaddingTop(20).AlignCenter().Text(text =>
                            {
                                text.Span("                                       \n").Underline();
                                text.Span("SK Treasurer");
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
            .Border(0.5f)
            .AlignCenter()
            .Padding(5);
    }

    static IContainer ListTableItemsLeft(IContainer container)
    {
        return container
            .Height(330)
            .MaxHeight(330)
            .Border(0.5f)
            .AlignLeft()
            .PaddingLeft(5)
            .Padding(1);
    }

    static IContainer ListTableItemsCenter(IContainer container)
    {
        return container
            .Height(330)
            .MaxHeight(330)
            .Border(0.5f)
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