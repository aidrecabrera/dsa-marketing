using dsa_marketing.Data.Repositories;
using dsa_marketing.Models;

namespace dsa_marketing.Data;

public interface IUnitOfWork : IDisposable
{
    IRepository<Transaction> Transactions { get; }
    IRepository<TransactionDocuments> TransactionDocuments { get; }
    IRepository<PurchaseRequest> PurchaseRequests { get; }
    IRepository<PurchaseOrder> PurchaseOrders { get; }
    IRepository<AbstractQuotation> AbstractQuotations { get; }
    IRepository<TransactionItem> TransactionItems { get; }

    int Complete();
}