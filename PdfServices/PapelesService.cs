// using QuestPDF.Fluent;
// using QuestPDF.Helpers;
// using QuestPDF.Infrastructure;
// using QuestPDF.Previewer;
// using System.Drawing;
// using System.Globalization;
// using System.Net;
// using System.Reflection.PortableExecutable;
//
// namespace dsa_marketing.Pdf
// {
//     public class PapelesService
//     {
//     
//     }
// }
//
//
// namespace HTMLToPDFWithQuestPDF
// {
//     class Program
//     {
//         [Obsolete]
//         static void Main(string[] args)
//         {
//             float borderThickness = 0.1f;
//             CultureInfo philippinesCulture = new CultureInfo("en-PH");
//
//             // PPMP
//             string ppmpUnit = null;
//             string ppmpAddress = null;
//
//             var purchaseOrder = Document.Create(container =>
//             {
//                 float totalCost = 0.00f;
//                 container.Page(page =>
//                 {
//                     page.Size(PageSizes.Letter);
//                     page.Margin(1, Unit.Centimetre);
//                     page.PageColor(Colors.White);
//                     page.DefaultTextStyle(x => x.FontSize(10));
//                     page.DefaultTextStyle(x => x.FontFamily(Fonts.Calibri));
//
//                     page.Header()
//                         .AlignRight()
//                         .Text("Appendix 1")
//                         .FontFamily("Arial")
//                         .FontSize(10)
//                         .LineHeight(1.5f)
//                         .FontColor(Colors.Green.Lighten1);
//
//                     page.Content().Column(c =>
//                     {
//                         c.Item().Border(0.1f).Table(table => {
//                             table.ColumnsDefinition(columns =>
//                             {
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                             });
//
//                             table.Cell()
//                                 .ColumnSpan(2)
//                                 .Row(1)
//                                 .Column(1)
//                                 .BorderBottom(borderThickness)
//                                 .Element(Block)
//                                 .Text("PURCHASE ORDER")
//                                 .Bold()
//                                 .FontSize(20);
//
//                             table.Cell()
//                                 .ColumnSpan(1)
//                                 .Row(2)
//                                 .Column(1)
//                                 .BorderBottom(borderThickness)
//                                 .BorderRight(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "Barangay: " +
//                                     "\n" +
//                                     "Tel. No:"
//                                 )
//                                 .LineHeight(1f)
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(2)
//                                 .Column(2)
//                                 .BorderBottom(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "City Municipality: " +
//                                     "\n" +
//                                     "Province: "
//                                 )
//                                 .LineHeight(1f)
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(3)
//                                 .Column(1)
//                                 .BorderBottom(borderThickness)
//                                 .BorderRight(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "Supplier: " +
//                                     "\n" +
//                                     "Address: "
//                                 )
//                                 .LineHeight(1f)
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(3)
//                                 .Column(2)
//                                 .BorderBottom(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "P.O. No.: " +
//                                     "\n" +
//                                     "Date: "
//                                 )
//                                 .LineHeight(1f)
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(4).Column(1)
//                                 .BorderBottom(borderThickness)
//                                 .BorderRight(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "TIN:")
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(4).Column(2).BorderBottom(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "Mode of Procurement:" +
//                                     "\n" +
//                                     "Bidding Negotiated Over the Counter")
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(2).Row(5).Column(1).BorderBottom(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "Gentlemen:" +
//                                     "\n" +
//                                     "           Please deliver to this Office the following articles subject to the terms and conditions contained herein.")
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(6).Column(1).BorderRight(borderThickness)
//                                 .Padding(5)
//                                 .Text(
//                                     "Place of Delivery: " +
//                                     "\n" +
//                                     "Date of Delivery: "
//                                 )
//                                 .LineHeight(1)
//                                 .FontSize(10);
//
//                             table.Cell().ColumnSpan(1).Row(6).Column(2)
//                                 .Padding(5)
//                                 .Text(
//                                     "Delivery Term: " +
//                                     "\n" +
//                                     "Payment Term: "
//                                 )
//                                 .LineHeight(1)
//                                 .FontSize(10);
//
//                         });
//                         c.Item().Border(0.1f).Height(250).MaxHeight(250).Table(itemList =>
//                         {
//                             itemList.ColumnsDefinition(categories =>
//                             {
//                                 categories.RelativeColumn();
//                                 categories.RelativeColumn();
//                                 categories.RelativeColumn();
//                                 categories.RelativeColumn();
//                                 categories.RelativeColumn();
//                                 categories.RelativeColumn();
//                                 categories.RelativeColumn();
//                             });
//
//                             itemList.Header(header =>
//                             {
//                                 header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Unit").FontSize(10).Bold();
//                                 header.Cell().ColumnSpan(3).Element(ItemCategoryHeader).Text("Particulars").FontSize(10).Bold();
//                                 header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Quantity").FontSize(10).Bold();
//                                 header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Unit Cost").FontSize(10).Bold();
//                                 header.Cell().ColumnSpan(1).Element(ItemCategoryHeader).Text("Amount").FontSize(10).Bold();
//                             });
//
//                             totalCost += AddItemToItemList(itemList, "Item " + 25, "Description " + 2, 25, 83f);
//                             for (global::System.Int32 i = 1; i <= 16; i++)
//                             {
//                                 if (i == 16)
//                                 {
//                                     totalCost += AddItemToItemListLast(itemList, "Item " + i, "Description " + i, 1, 283f);
//                                 } else
//                                 {
//                                     totalCost += AddItemToItemList(itemList, "Item " + i, "Description " + i, 25, 2583f);
//                                 }
//                             }
//
//                         });
//                         c.Item().Border(0.1f).Padding(5).Table(transactionInformation =>
//                         {
//                             transactionInformation.ColumnsDefinition(columns =>
//                             {
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                                 columns.RelativeColumn();
//                             });
//                             
//                             transactionInformation.Cell().ColumnSpan(2).Text("(Total Amount in Words)").FontSize(10).Italic();
//                             transactionInformation.Cell().ColumnSpan(5).Text(totalCost.ToString("C", philippinesCulture)).FontSize(9);
//                             transactionInformation.Cell().ColumnSpan(1).PaddingRight(5).AlignRight().Text(totalCost.ToString("C", philippinesCulture)).FontSize(10);
//                         });
//                         c.Item().Border(0.1f).Padding(5).Table(transactionCondition =>
//                         {
//                             transactionCondition.ColumnsDefinition(area =>
//                             {
//                                 area.RelativeColumn();
//                                 area.RelativeColumn();
//                                 area.RelativeColumn();
//                                 area.RelativeColumn();
//                                 area.RelativeColumn();
//                             });
//                             transactionCondition.Cell().ColumnSpan(5).Text("In case of failure to make full delivery within the time specified above, a penalty of one-tenth (1/10) of one percent for every of delay shall be imposed.").FontSize(10);
//                             transactionCondition.Cell().ColumnSpan(2).Column(4).Row(2)
//                                 .Text(
//                                     "Very Truly yours," +
//                                     "\n" +
//                                     "\nPUNONG BARANGAY NAME" +
//                                     "\nSK CHAIRMAN" +
//                                     "\nDate: ___________" +
//                                     "\n"
//                                 )
//                                 .FontSize(10);
//                         });
//                         c.Item().BorderHorizontal(0.1f).Table(transactionSignature =>
//                         {
//                             transactionSignature.ColumnsDefinition(divider =>
//                             {
//                                 divider.RelativeColumn();
//                                 divider.RelativeColumn();
//                             });
//                             transactionSignature.Cell().Padding(5).Text("Conforme:").FontSize(10);
//                             transactionSignature.Cell().ColumnSpan(1).Column(1).Row(1).BorderVertical(0.1f).Padding(1).AlignCenter().Text("\n\nDSA Marketing:").Underline().FontSize(10);
//                             transactionSignature.Cell().ColumnSpan(1).Column(1).Row(2).BorderVertical(0.1f).Padding(1).AlignCenter().Text("Signature over Printed Name of Supplier").FontSize(10);
//                             transactionSignature.Cell().ColumnSpan(1).Column(1).Row(3).BorderVertical(0.1f).Padding(1).AlignCenter().Text("Date: ___________\n\n").FontSize(10);
//
//                             transactionSignature.Cell().ColumnSpan(1).Column(2).Row(1).Padding(5).Text("Existence of Available Appropriation:").FontSize(10);
//                             transactionSignature.Cell().ColumnSpan(1).Column(2).Row(1).BorderRight(0.1f).Padding(1).AlignCenter().Text("\n\n____________________").FontSize(10);
//                             transactionSignature.Cell().ColumnSpan(1).Column(2).Row(2).BorderRight(0.1f).Padding(1).AlignCenter().Text("Chairman, Committee on Appropriation").FontSize(10);
//                             transactionSignature.Cell().ColumnSpan(1).Column(2).Row(3).BorderRight(0.1f).Padding(1).AlignCenter().Text("Date: ___________\n\n").FontSize(10);
//
//                         });
//                     });
//                 });
//             });
//
//             var projectProcurementProjectPlan = Document.Create(container =>
//             {
//                 container.Page(page =>
//                 {
//                     page.Size(PageSizes.A4.Landscape());
//                     page.Margin(0.75f, Unit.Centimetre);
//                     page.PageColor(Colors.White);
//                     page.DefaultTextStyle(x => x.FontSize(10));
//                     page.DefaultTextStyle(x => x.FontFamily(Fonts.Calibri));
//                     page.Header().Column(headerSection =>
//                     {
//                         headerSection.Item().AlignCenter().Text(header =>
//                         {
//                             header.Span("PROJECT PROCUREMENT MANAGEMENT PLAN").FontFamily(Fonts.Calibri).FontSize(20).Bold().Underline();
//                             header.Span(" (PPMP)").FontFamily(Fonts.Calibri).FontSize(20).Bold();
//                         });
//                         headerSection.Item().AlignLeft().PaddingTop(15).PaddingLeft(75).Table(euu =>
//                         {
//                             euu.ColumnsDefinition(column =>
//                             {
//                                 column.ConstantColumn(100);
//                                 column.ConstantColumn(250);
//                             });
//                             euu.Cell().ColumnSpan(1).Column(1).Row(1).AlignLeft().Text("END-USER/UNIT");
//                             euu.Cell().ColumnSpan(1).Column(2).Row(1).AlignLeft().BorderBottom(0.5f).Text("                               ");
//                             if (ppmpUnit != null)
//                             {
//                                 euu.Cell().ColumnSpan(1).Column(2).Row(1).AlignLeft().Text(ppmpUnit);
//                             }
//                         });
//                         headerSection.Item().AlignLeft().PaddingLeft(75).Table(address =>
//                         {
//                             address.ColumnsDefinition(column =>
//                             {
//                                 column.ConstantColumn(100);
//                                 column.ConstantColumn(250);
//                             });
//                             address.Cell().ColumnSpan(1).Column(1).Row(1).AlignLeft().Text("Address");
//                             address.Cell().ColumnSpan(1).Column(2).Row(1).AlignLeft().BorderBottom(0.5f).Text("                               ");
//                             if (ppmpAddress != null)
//                             {
//                                 address.Cell().ColumnSpan(1).Column(2).Row(1).AlignLeft().Text(ppmpAddress);
//                             }
//                         });
//                     });
//                     page.Content().Column(contentSection =>
//                     {
//                         contentSection.Item().PaddingTop(10).Element(PpmpTable).Table(main =>
//                         {
//                             main.ColumnsDefinition(columns =>
//                             {
//                                 for (global::System.Int32 i = 0; i < 21; i++)
//                                 {
//                                     columns.RelativeColumn();
//                                 }
//                             });
//
//                             main.Header(header =>
//                             {
//                                 header.Cell().RowSpan(2).ColumnSpan(1).Element(PpmpHeader).Text("CODE").FontSize(10);
//                                 header.Cell().RowSpan(2).ColumnSpan(4).Element(PpmpHeader).Text("GENERAL DESCRIPTION").FontSize(10);
//                                 header.Cell().RowSpan(2).ColumnSpan(2).Element(PpmpHeader).Text("QUANTITY/SIZE").FontSize(10);
//                                 header.Cell().RowSpan(2).ColumnSpan(2).Element(PpmpHeader).Text(budget =>
//                                 {
//                                     budget.AlignCenter();
//                                     budget.Span("ESTIMATED").FontSize(10).LineHeight(1);
//                                     budget.Span("BUDGET").FontSize(10).LineHeight(1);
//                                 });
//
//                                 header.Cell().RowSpan(1).ColumnSpan(12).Element(PpmpHeader).Text("SCHEDULE/MILESTONE OF ACTIVITIES").Bold().FontSize(12);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("JAN").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("FEB").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("MAR").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("APR").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("MAY").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("JUN").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("JUL").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("AUG").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("SEP").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("OCT").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("NOV").FontSize(10);
//                                 header.Cell().RowSpan(1).ColumnSpan(1).BorderTop(0.1f).Element(PpmpHeader).Text("DEC").FontSize(10);
//                             });
//                             for (global::System.Int32 i = 0; i < 25; i++)
//                             {
//                                 GenerateTable(main);
//                             }
//                             for (global::System.Int32 i = 0; i < 28; i++)
//                             {
//                                 PpmpItems(main, "Test", "Test", "Test", 25000);
//                             }
//                         });
//                     });
//                 });
//             });
//
//             purchaseOrder.ShowInPreviewer();
//         }
//         static IContainer PpmpTable(IContainer container)
//         {
//             return container
//                 .ShowOnce()
//                 .BorderHorizontal(0.1f)
//                 .BorderVertical(0.1f)
//                 .ExtendVertical();
//         }
//         static IContainer PpmpHeader(IContainer container)
//         {
//             return container
//                 .ShowOnce()
//                 .BorderVertical(0.1f)
//                 .BorderBottom(0.1f)
//                 .AlignCenter()
//                 .AlignMiddle();
//         }
//         static IContainer PpmpItemsDecorate(IContainer container)
//         {
//             return container
//                 .BorderVertical(0.1f)
//                 .ExtendHorizontal()
//                 .ShowOnce();
//         }
//         static void GenerateTable(TableDescriptor container)
//         {
//             container.Cell().ColumnSpan(1).Element(PpmpItemsDecorate).BorderBottom(0.1f);
//             container.Cell().ColumnSpan(4).Element(PpmpItemsDecorate).BorderBottom(0.1f);
//             container.Cell().ColumnSpan(2).Element(PpmpItemsDecorate).BorderBottom(0.1f);
//             container.Cell().ColumnSpan(2).Element(PpmpItemsDecorate).BorderBottom(0.1f);
//
//             for (int i = 0; i < 12; i++)
//             {
//                 container.Cell().ColumnSpan(1).Element(PpmpItemsDecorate).BorderBottom(0.1f);
//             }
//         }
//
//         [Obsolete]
//         static void PpmpItems(TableDescriptor item, string description, string qty, string size, float budget)
//         {
//             item.Cell().ColumnSpan(1);
//             item.Cell().ColumnSpan(4).PaddingLeft(5).PaddingRight(5).AlignLeft().Text(description).FontSize(10);
//             item.Cell().ColumnSpan(2).PaddingLeft(5).PaddingRight(5).AlignCenter().Text(qty+"/"+size).FontSize(10);
//             item.Cell().ColumnSpan(2).PaddingLeft(5).PaddingRight(5).AlignCenter().Text(budget).FontSize(10);
//
//             for (int i = 0; i < 12; i++)
//             {
//                 item.Cell().ColumnSpan(1);
//             }
//         }
//         static IContainer Block(IContainer container)
//         {
//             return container
//                 .ShowOnce()
//                 .MinWidth(50)
//                 .MinHeight(25)
//                 .AlignCenter()
//                 .AlignMiddle();
//         }
//         static IContainer ItemCategoryHeader(IContainer container)
//         {
//             return container
//                 .BorderVertical(0.1f)
//                 .BorderBottom(0.1f)
//                 .ShowOnce()
//                 .AlignCenter()
//                 .AlignMiddle();
//         }
//         static IContainer ItemFormat(IContainer container)
//         {
//             return container
//                 .BorderVertical(0.1f)
//                 .ShowOnce()
//                 .AlignMiddle();
//         }
//         static float AddItemToItemList(TableDescriptor itemList, string itemName, string description, int quantity, float unitCost)
//         {
//             CultureInfo philippinesCulture = new CultureInfo("en-PH");
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignCenter().Text(itemName).FontSize(10);
//             itemList.Cell().ColumnSpan(3).Element(ItemFormat).AlignLeft().PaddingLeft(10).Text(description).FontSize(10);
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignCenter().Text(quantity.ToString()).FontSize(10);
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text(unitCost.ToString("C", philippinesCulture)).FontSize(10);
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text((quantity * unitCost).ToString("C", philippinesCulture)).FontSize(10);
//             return quantity * unitCost;
//         }
//         static float AddItemToItemListLast(TableDescriptor itemList, string itemName, string description, int quantity, float unitCost)
//         {
//             CultureInfo philippinesCulture = new CultureInfo("en-PH");
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignCenter().Text(itemName).FontSize(10);
//             itemList.Cell().ColumnSpan(3).Element(ItemFormat).AlignLeft().PaddingLeft(10).Text(description).FontSize(10);
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignCenter().Text(quantity.ToString()).FontSize(10);
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text(unitCost.ToString("C", philippinesCulture)).FontSize(10);
//             itemList.Cell().ColumnSpan(1).Element(ItemFormat).AlignRight().PaddingLeft(10).PaddingRight(10).Text((quantity * unitCost).ToString("C", philippinesCulture)).FontSize(10).Underline();
//             return quantity * unitCost;
//         }
//     }
// }