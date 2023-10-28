using Aneta.Models;
using dsa_marketing.Data.Repositories;

namespace Aneta.Data;

public interface IUnitOfWork : IDisposable
{
    IRepository<Transactions> Transactions { get; }
    IRepository<TransactionDocument> TransactionDocuments { get; }
    IRepository<PurchaseRequest> PurchaseRequests { get; }
    IRepository<PurchaseOrder> PurchaseOrders { get; }
    IRepository<AbstractQuotation> AbstractQuotations { get; }
    IRepository<TransactionItem> TransactionItems { get; }
    int Complete();
}