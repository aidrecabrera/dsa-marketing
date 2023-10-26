using Aneta.Data.Repositories;
using Aneta.Models;
using dsa_marketing.Data.Repositories;

namespace Aneta.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DsaClusterContext? _context;

    public UnitOfWork(DsaClusterContext? context)
    {
        _context = context;
        Transaction = new SqlRepository<Transaction>(_context);
        TransactionDocuments = new SqlRepository<TransactionDocument>(_context);
        PurchaseRequests = new SqlRepository<PurchaseRequest>(_context);
        PurchaseOrders = new SqlRepository<PurchaseOrder>(_context);
        AbstractQuotations = new SqlRepository<AbstractQuotation>(_context);
        TransactionItems = new SqlRepository<TransactionItem>(_context);
        TransactionSummary = new SqlRepository<TransactionSummary>(_context);
        ExistingTransactionsSummary = new SqlRepository<ExistingTransactionsSummary>(_context);
    }

    public IRepository<Transaction> Transaction { get; private set; }
    public IRepository<TransactionDocument> TransactionDocuments { get; private set; }
    public IRepository<PurchaseRequest> PurchaseRequests { get; private set; }
    public IRepository<PurchaseOrder> PurchaseOrders { get; private set; }
    public IRepository<AbstractQuotation> AbstractQuotations { get; private set; }
    public IRepository<TransactionItem> TransactionItems { get; private set; }
    public IRepository<TransactionSummary> TransactionSummary { get; set; }

    public IRepository<ExistingTransactionsSummary>? ExistingTransactionsSummary { get; set; }
    
    public int Complete()
    {
        return _context!.SaveChanges();
    }
    
    public async Task<int> CompleteAsync()
    {
        return await _context?.SaveChangesAsync()!;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}