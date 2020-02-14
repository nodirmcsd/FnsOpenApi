using FnsOpenApi.Domain.Models;
using FnsOpenApi.Domain.Models.ReceiptResponse;

namespace FnsOpenApi.Domain.Interfaces
{
    public interface IFnsApiClient
    {
        string GetAuthToken(string masterToken);
        ReceiptCheck CheckReceipt(string token, Receipt receipt, string appClientId);
        ReceiptDetails GetReceiptDetails(string token, Receipt receipt, string appClientId);
    }
}
