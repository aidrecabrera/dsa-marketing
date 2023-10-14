using dsa_marketing.Models;

namespace dsa_marketing.Data
{
    public interface ITransactionsBuilder
    {
        TransactionsModel Build();
        ITransactionsBuilder SetWithAmount(List<decimal> value);
        ITransactionsBuilder SetWithApprovedForIssuanceName(string value);
        ITransactionsBuilder SetWithAwardedToThe(string value);
        ITransactionsBuilder SetWithBarangayName(string value);
        ITransactionsBuilder SetWithBarangayTreasurerName(string value);
        ITransactionsBuilder SetWithCost(List<decimal> value);
        ITransactionsBuilder SetWithDeliveryDate(DateTime value);
        ITransactionsBuilder SetWithDeliveryLocation(string value);
        ITransactionsBuilder SetWithDeliveryTerms(string value);
        ITransactionsBuilder SetWithModeOfProcurement(string value);
        ITransactionsBuilder SetWithMunicipalityName(string value);
        ITransactionsBuilder SetWithOfficeLocation(string value);
        ITransactionsBuilder SetWithOfficeOfThe(string value);
        ITransactionsBuilder SetWithOpenDate(DateTime value);
        ITransactionsBuilder SetWithOpeningQuotationsOffice(string value);
        ITransactionsBuilder SetWithParticulars(List<string> value);
        ITransactionsBuilder SetWithPrice(decimal value);
        ITransactionsBuilder SetWithPunongBarangayName(string value);
        ITransactionsBuilder SetWithPurpose(string value);
        ITransactionsBuilder SetWithQuantity(List<int> value);
        ITransactionsBuilder SetWithRequestDate(DateTime value);
        ITransactionsBuilder SetWithRequestedByName(string value);
        ITransactionsBuilder SetWithRequestNumber(string value);
        ITransactionsBuilder SetWithRequestorName(string value);
        ITransactionsBuilder SetWithRequisition(string value);
        ITransactionsBuilder SetWithTransactionId(int value);
        ITransactionsBuilder SetWithUnitName(List<string> value);
    }
}