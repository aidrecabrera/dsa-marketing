using System.Globalization;
using dsa_marketing.Data;
using dsa_marketing.Models;
using dsa_marketing.PdfServices.Immutables;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Humanizer;

namespace dsa_marketing.PdfServices.Templates;

public class PurchaseOrder
{
    private static DocumentParameters _documentParameters = new()
    {
        Margin = 1,
        FontSize = 10,
        Font = "Calibri",
        LineHeight = 1f,
        Border = 0.1f
    };
    public Document DsaTemplate(TransactionInfo transactionInfo, List<TransactionItem> transactionItems)
    {
        return Document.Create(container =>
        {
            var borderThickness = _documentParameters.Border;
            var philippinesCulture = _documentParameters.PhilippinesCulture;

            float totalCost = 0.00f;
            
            container.Page(page =>
            {
                page.Size(PageSizes.Letter);
                page.Margin(_documentParameters.Margin, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(_documentParameters.FontSize));
                page.DefaultTextStyle(x => x.FontFamily(_documentParameters.Font));

                page.Header()
                    .AlignRight()
                    .Text("Appendix 1")
                    .FontFamily(_documentParameters.Font)
                    .FontSize(_documentParameters.FontSize)
                    .LineHeight(_documentParameters.LineHeight)
                    .FontColor(Colors.Green.Lighten1);

                page.Content().Column(c =>
                {
                    c.Item().Border(_documentParameters.Border).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Cell()
                            .ColumnSpan(2)
                            .Row(1)
                            .Column(1)
                            .BorderBottom(borderThickness)
                            .Element(Block)
                            .Text("PURCHASE ORDER")
                            .Bold()
                            .FontSize(20);

                        table.Cell()
                            .ColumnSpan(1)
                            .Row(2)
                            .Column(1)
                            .BorderBottom(borderThickness)
                            .BorderRight(borderThickness)
                            .Padding(5)
                            .Text(
                                "Barangay: " + transactionInfo.Barangay +
                                "\n" +
                                "Tel. No: "
                            )
                            .LineHeight(1f)
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(2)
                            .Column(2)
                            .BorderBottom(borderThickness)
                            .Padding(5)
                            .Text(
                                "City Municipality: " + transactionInfo.Municipality +
                                "\n" +
                                "Province: " + transactionInfo.Province
                            )
                            .LineHeight(1f)
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(3)
                            .Column(1)
                            .BorderBottom(borderThickness)
                            .BorderRight(borderThickness)
                            .Padding(5)
                            .Text(
                                "Supplier: " + transactionInfo.Supplier +
                                "\n" +
                                "Address: " + transactionInfo.Address
                            )
                            .LineHeight(1f)
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(3)
                            .Column(2)
                            .BorderBottom(borderThickness)
                            .Padding(5)
                            .Text(
                                "P.O. No.: " + transactionInfo.Po +
                                "\n" +
                                "Date: "
                            )
                            .LineHeight(1f)
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(4).Column(1)
                            .BorderBottom(borderThickness)
                            .BorderRight(borderThickness)
                            .Padding(5)
                            .Text(
                                "TIN: " + transactionInfo.Tin)
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(4).Column(2).BorderBottom(borderThickness)
                            .Padding(5)
                            .Text(
                                "Mode of Procurement:" +
                                "\n" +
                                "[ ] Bidding [ ] Negotiated [ ] Over the Counter")
                            .FontSize(10);

                        table.Cell().ColumnSpan(2).Row(5).Column(1).BorderBottom(borderThickness)
                            .Padding(5)
                            .Text(
                                "Gentlemen:" +
                                "\n" +
                                "           Please deliver to this Office the following articles subject to the terms and conditions contained herein.")
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(6).Column(1).BorderRight(borderThickness)
                            .Padding(5)
                            .Text(
                                "Place of Delivery: " + transactionInfo.DeliveryPlace +
                                "\n" +
                                "Date of Delivery: " + transactionInfo.DeliveryDate
                            )
                            .LineHeight(1)
                            .FontSize(10);

                        table.Cell().ColumnSpan(1).Row(6).Column(2)
                            .Padding(5)
                            .Text(
                                "Delivery Term: " + transactionInfo.DeliveryDate +
                                "\n" +
                                "Payment Term: " + transactionInfo.TermPayment
                            )
                            .LineHeight(1)
                            .FontSize(10);
                    });
                    c.Item().Border(0.1f).Height(250).MaxHeight(250).Table(itemList =>
                    {
                        itemList.ColumnsDefinition(categories =>
                        {
                            categories.RelativeColumn();
                            categories.RelativeColumn();
                            categories.RelativeColumn();
                            categories.RelativeColumn();
                            categories.RelativeColumn();
                            categories.RelativeColumn();
                            categories.RelativeColumn();
                        });

                        itemList.Header(header =>
                        {
                            header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Unit").FontSize(10).Bold();
                            header.Cell().ColumnSpan(3).Element(ItemCategoryHeader).Text("Particulars").FontSize(10)
                                .Bold();
                            header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Quantity").FontSize(10)
                                .Bold();
                            header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Unit Cost").FontSize(10)
                                .Bold();
                            header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Amount").FontSize(10).Bold();
                        });
                        uint row = 1;
                        foreach (var i in transactionItems)
                        {
                            totalCost += Item(row, itemList, i.UnitName, i.Particulars, (int)i.Quantity!, (float)i.Cost!);
                            row++;
                        }
                        Item(itemList, false);
                    });
                    c.Item().Border(0.1f).Padding(5).Table(transactionInformation =>
                    {
                        transactionInformation.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        transactionInformation.Cell().ColumnSpan(2).Text("(Total Amount in Words)").FontSize(10)
                            .Italic();
                        int humanizedCost = (int)totalCost;
                        transactionInformation.Cell().ColumnSpan(5).Text(humanizedCost.ToWords().Transform(To.UpperCase))
                            .FontSize(9);
                        transactionInformation.Cell().ColumnSpan(1).PaddingRight(5).AlignRight()
                            .Text(totalCost.ToString("C", philippinesCulture)).FontSize(10);
                    });
                    c.Item().Border(0.1f).Padding(5).Table(transactionCondition =>
                    {
                        transactionCondition.ColumnsDefinition(area =>
                        {
                            area.RelativeColumn();
                            area.RelativeColumn();
                            area.RelativeColumn();
                            area.RelativeColumn();
                            area.RelativeColumn();
                        });
                        transactionCondition.Cell().ColumnSpan(5)
                            .Text(
                                "In case of failure to make full delivery within the time specified above, a penalty of one-tenth (1/10) of one percent for every of delay shall be imposed.")
                            .FontSize(10);
                        transactionCondition.Cell().ColumnSpan(2).Column(4).Row(2)
                            .Text(
                                "Very Truly yours," +
                                "\n" +
                                transactionInfo.PunongBarangay +
                                "\nSK CHAIRMAN" +
                                "\nDate: ___________" +
                                "\n"
                            )
                            .FontSize(10);
                    });
                    c.Item().BorderHorizontal(0.1f).Table(transactionSignature =>
                    {
                        transactionSignature.ColumnsDefinition(divider =>
                        {
                            divider.RelativeColumn();
                            divider.RelativeColumn();
                        });
                        transactionSignature.Cell().Padding(5).Text("Conforme:").FontSize(10);
                        transactionSignature.Cell().ColumnSpan(1).Column(1).Row(1).BorderVertical(0.1f).Padding(1)
                            .AlignCenter().Text("\n\nDSA Marketing:").Underline().FontSize(10);
                        transactionSignature.Cell().ColumnSpan(1).Column(1).Row(2).BorderVertical(0.1f).Padding(1)
                            .AlignCenter().Text("Signature over Printed Name of Supplier").FontSize(10);
                        transactionSignature.Cell().ColumnSpan(1).Column(1).Row(3).BorderVertical(0.1f).Padding(1)
                            .AlignCenter().Text("Date: ___________\n\n").FontSize(10);

                        transactionSignature.Cell().ColumnSpan(1).Column(2).Row(1).Padding(5)
                            .Text("Existence of Available Appropriation:").FontSize(10);
                        transactionSignature.Cell().ColumnSpan(1).Column(2).Row(1).BorderRight(0.1f).Padding(1)
                            .AlignCenter().Text("\n\n____________________").FontSize(10);
                        transactionSignature.Cell().ColumnSpan(1).Column(2).Row(2).BorderRight(0.1f).Padding(1)
                            .AlignCenter().Text("Chairman, Committee on Appropriation").FontSize(10);
                        transactionSignature.Cell().ColumnSpan(1).Column(2).Row(3).BorderRight(0.1f).Padding(1)
                            .AlignCenter().Text("Date: ___________\n\n").FontSize(10);

                        
                    });
                });
            });
        });
    }

    public IContainer Block(IContainer container)
    {
        return container
            .ShowOnce()
            .MinWidth(50)
            .MinHeight(25)
            .AlignCenter()
            .AlignMiddle();
    }

    public IContainer ItemCategoryHeader(IContainer container)
    {
        return container
            .BorderVertical(0.1f)
            .BorderBottom(0.1f)
            .ShowOnce()
            .AlignCenter()
            .AlignMiddle();
    }

    public IContainer ItemFormat(IContainer container)
    {
        return container
            .BorderVertical(0.1f)
            .ShowOnce()
            .AlignMiddle();
    }
    public void Item(TableDescriptor itemList, bool underlineLastCell)
    {
        var philippinesCulture = new CultureInfo("en-PH");
        itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignCenter().ExtendVertical().Text("");
        itemList.Cell().ColumnSpan(3).Element(ItemFormat).AlignLeft().ExtendVertical().Text("");
        itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignCenter().ExtendVertical().Text("");
        itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().ExtendVertical().Text("");
        if (underlineLastCell)
            itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).ExtendVertical().Text("");
        else
            itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).ExtendVertical().Text("");
    }
    public float Item(uint i, TableDescriptor itemList, string? itemName, string? description, int quantity, float unitCost,
        bool underlineLastCell = false)
    {
        var philippinesCulture = new CultureInfo("en-PH");
        
        itemList.Cell().Row(i).Column(1).ColumnSpan(1).Element(ItemFormat).AlignCenter().Text(itemName).FontSize(10);
        itemList.Cell().Row(i).Column(2).ColumnSpan(3).Element(ItemFormat).AlignLeft().PaddingLeft(10).Text(description).FontSize(10);
        itemList.Cell().Row(i).Column(5).ColumnSpan(1).Element(ItemFormat).AlignCenter().Text(quantity.ToString()).FontSize(10);
        itemList.Cell().Row(i).Column(6).ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text(unitCost.ToString("C", philippinesCulture)).FontSize(10);

        if (underlineLastCell)
            itemList.Cell().Row(i).Column(7).ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text((quantity * unitCost).ToString("C", philippinesCulture)).FontSize(10).Underline();
        else
            itemList.Cell().Row(i).Column(7).ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text((quantity * unitCost).ToString("C", philippinesCulture)).FontSize(10);

        return quantity * unitCost;
    }
}