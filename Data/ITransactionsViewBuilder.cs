using dsa_marketing.Models;

namespace dsa_marketing.Data
{
    public interface ITransactionsViewBuilder
    {
        TransactionViewModel Build();
        ITransactionsViewBuilder SetWithAmount(decimal value);
        ITransactionsViewBuilder SetWithApprovedForIssuanceName(string value);
        ITransactionsViewBuilder SetWithAwardedToThe(string value);
        ITransactionsViewBuilder SetWithBarangayName(string value);
        ITransactionsViewBuilder SetWithBarangayTreasurerName(string value);
        ITransactionsViewBuilder SetWithCost(decimal value);
        ITransactionsViewBuilder SetWithDeliveryDate(DateTime? value);
        ITransactionsViewBuilder SetWithDeliveryLocation(string value);
        ITransactionsViewBuilder SetWithDeliveryTerms(string value);
        ITransactionsViewBuilder SetWithModeOfProcurement(string value);
        ITransactionsViewBuilder SetWithMunicipalityName(string value);
        ITransactionsViewBuilder SetWithOfficeLocation(string value);
        ITransactionsViewBuilder SetWithOfficeOfThe(string value);
        ITransactionsViewBuilder SetWithOpenDate(DateTime? value);
        ITransactionsViewBuilder SetWithOpeningQuotationsOffice(string value);
        ITransactionsViewBuilder SetWithParticulars(string value);
        ITransactionsViewBuilder SetWithPrice(decimal value);
        ITransactionsViewBuilder SetWithPunongBarangayName(string value);
        ITransactionsViewBuilder SetWithPurpose(string value);
        ITransactionsViewBuilder SetWithQuantity(int value);
        ITransactionsViewBuilder SetWithRequestDate(DateTime? value);
        ITransactionsViewBuilder SetWithRequestedByName(string value);
        ITransactionsViewBuilder SetWithRequestNumber(string value);
        ITransactionsViewBuilder SetWithRequestorName(string value);
        ITransactionsViewBuilder SetWithRequisition(string value);
        ITransactionsViewBuilder SetWithTransactionId(int value);
        ITransactionsViewBuilder SetWithUnitName(string value);
    }
}