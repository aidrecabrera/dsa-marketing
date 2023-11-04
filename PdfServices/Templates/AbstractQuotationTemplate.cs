using Aneta.Models;
using Aneta.PdfServices.Immutables;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Aneta.PdfServices.Templates;

public class AbstractQuotationTemplate
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
                    tableRow.Item().Table(header =>
                    {
                        header.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                        header.Cell().PaddingBottom(15).Text(text =>
                        {
                            text.AlignCenter();
                            text.Span("ABSTRACT OF QUOTATION").Bold().FontSize(25);
                        });
                    });
                    tableRow.Item().Table(content =>
                    {
                        content.ColumnsDefinition(columns => { columns.RelativeColumn(); });
                        content.Cell().PaddingBottom(10).Text(text =>
                        {
                            text.Span("Open on ");
                            text.Span("                                                      ").Underline();
                            text.Span(" at ");
                            text.Span("                                                      ").Underline();
                            text.Span(" at the office of the ");
                            text.Span(
                                    "                                                                                                       ")
                                .Underline();
                            text.Span(" For the use in the office of the ");
                            text.Span(
                                    "                                                                                     ")
                                .Underline();
                        });
                        content.Cell().Text(text => { text.Span("Received from the following dealers:").Bold(); });
                    });
                    tableRow.Item().Border(0.5f).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(250);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        table.Cell().Column(1).BorderRight(0.5f).AlignCenter().AlignMiddle().Text(header =>
                        {
                            header.Span("ARTICLES AND/OR MATERIALS ADVERTISED");
                        });
                        table.Cell().Column(2).BorderRight(0.5f).AlignCenter().AlignMiddle()
                            .Text(header => { header.Span("DSA MARKETING"); });
                        table.Cell().Column(3).BorderRight(0.5f).AlignCenter().AlignMiddle()
                            .Text(header => { header.Span("PAPER HOUSE"); });
                        table.Cell().Column(4).BorderRight(0.5f).AlignCenter().AlignMiddle().Text(header =>
                        {
                            header.Span("JOHANNA’S MARKETING");
                        });
                    });
                    tableRow.Item().Border(0.5f).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(250);
                            columns.RelativeColumn();
                        });
                        table.Cell().Column(1).BorderRight(0.5f).Height(350).AlignCenter().Table(items =>
                        {
                            items.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            items.Cell().Column(1).BorderRight(0.5f).Height(350).Text(text => { text.Span(""); });
                            items.Cell().Column(2).BorderRight(0.5f).Height(350).Text(text => { text.Span(""); });
                            items.Cell().Column(3).BorderRight(0.5f).Height(350).Text(text => { text.Span(""); });
                        });
                        table.Cell().Column(2).BorderRight(0.5f).Height(350).AlignCenter().Table(items =>
                        {
                            items.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            items.Cell().BorderRight(0.5f).Height(350).Text(text => { text.Span(""); });
                            items.Cell().BorderRight(0.5f).Height(350).Text(text => { text.Span(""); });
                            items.Cell().BorderRight(0.5f).Height(350).Text(text => { text.Span(""); });
                        });
                    });
                    tableRow.Item().PaddingTop(5).Text(text =>
                    {
                        text.Span("RECOMMENDATIONS: ").Bold().Italic();
                        text.Span(
                                "it is hereby recommend that the above articles and/or materials be awarded to the ")
                            .Italic();
                        text.Span("                                                           ").Underline().Italic();
                        text.Span(
                            " of");
                        text.Span("                                                           ").Underline().Italic();
                        text.Span(
                                " having the lowest price in the locality and has the complete and best kind of stocks which is most advantageous to the government. There were three (3) dealers that submitted their quotation.")
                            .Italic();
                        text.Span(
                                "\n               We, the undersigned hereby certify that we actually present during the opening of the quotations at the office of the ")
                            .Italic();
                        text.Span("                                                                     ").Underline().Italic();
                        text.Span(
                                " and that the process quoted by each dealer are just and more advantageous to the government.")
                            .Italic();
                    });
                    tableRow.Item().PaddingBottom(5).AlignCenter().Text(members =>
                    {
                        members.Span("MEMBERS COMMITTEE ON AWARD").Bold();
                    });
                    tableRow.Item().Table(memberTable =>
                    {
                        memberTable.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        memberTable.Cell().Column(1).Row(1).AlignCenter()
                            .Text("                                        ").Underline();
                        memberTable.Cell().Column(1).Row(2).AlignCenter().Text("Chairman");
                        memberTable.Cell().Column(2).Row(1).AlignCenter()
                            .Text("                                        ").Underline();
                        memberTable.Cell().Column(2).Row(2).AlignCenter().Text("Member");
                        memberTable.Cell().Column(3).Row(1).AlignCenter()
                            .Text("                                        ").Underline();
                        memberTable.Cell().Column(3).Row(2).AlignCenter().Text("Member");

                        memberTable.Cell().Column(1).Row(3).AlignCenter()
                            .Text("                                        ").Underline();
                        memberTable.Cell().Column(1).Row(4).AlignCenter().Text("Member ");
                        memberTable.Cell().Column(2).Row(3).AlignCenter()
                            .Text("                                        ").Underline();
                        memberTable.Cell().Column(2).Row(4).AlignCenter().Text("Member");
                        memberTable.Cell().Column(3).Row(3).AlignCenter()
                            .Text("                                        ").Underline();
                        memberTable.Cell().Column(3).Row(4).AlignCenter().Text("Member");
                    });
                });
            });
        });
    }
}