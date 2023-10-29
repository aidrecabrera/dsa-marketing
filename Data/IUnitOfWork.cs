using Aneta.Models;
using dsa_marketing.Data.Repositories;

namespace Aneta.Data;

public interface IUnitOfWork : IDisposable
{
    IRepository<TransactionDetail> TransactionDetails { get; }
    IRepository<TransactionDocument> TransactionDocuments { get; }
    IRepository<PurchaseRequest> PurchaseRequests { get; }
    IRepository<PurchaseOrder> PurchaseOrders { get; }
    IRepository<AbstractQuotation> AbstractQuotations { get; }
    IRepository<TransactionItem> TransactionItems { get; }
    IRepository<TransactionSummary> TransactionSummary { get; }
    IRepository<ExistingTransactionSummary> ExistingTransactionSummary { get; }
    int Complete();
}