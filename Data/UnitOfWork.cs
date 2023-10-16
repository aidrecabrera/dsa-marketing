using dsa_marketing.Data.Repositories;
using dsa_marketing.Models;

namespace dsa_marketing.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DsaClusterContext _context;

    public UnitOfWork(DsaClusterContext context)
    {
        _context = context;
        Transaction = new GenericRepository<Transaction>(_context);
        TransactionDocuments = new GenericRepository<TransactionDocuments>(_context);
        PurchaseRequests = new GenericRepository<PurchaseRequest>(_context);
        PurchaseOrders = new GenericRepository<PurchaseOrder>(_context);
        AbstractQuotations = new GenericRepository<AbstractQuotation>(_context);
        TransactionItems = new GenericRepository<TransactionItem>(_context);
    }

    public IRepository<Transaction> Transaction { get; private set; }
    public IRepository<TransactionDocuments> TransactionDocuments { get; private set; }
    public IRepository<PurchaseRequest> PurchaseRequests { get; private set; }
    public IRepository<PurchaseOrder> PurchaseOrders { get; private set; }
    public IRepository<AbstractQuotation> AbstractQuotations { get; private set; }
    public IRepository<TransactionItem> TransactionItems { get; private set; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}