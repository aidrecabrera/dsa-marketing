using dsa_marketing.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace dsa_marketing.PdfServices.Immutables;

public interface IPdfTemplate
{
    public Document DsaTemplate(TransactionInfo transactionInfo, List<TransactionItem> transactionItems);
    public float Item(
        TableDescriptor itemList, 
        string itemName, 
        string description, 
        int quantity, 
        float unitCost, 
        bool underlineLastCell);
    public IContainer Block(IContainer container);
    public IContainer ItemCategoryHeader(IContainer container);
    public IContainer ItemFormat(IContainer container);
}