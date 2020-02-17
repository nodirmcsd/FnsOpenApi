using FnsOpenApi.Client.Models;
using FnsOpenApi.Client.Models.ReceiptResponse;

namespace FnsOpenApi.Client.Interfaces
{
    public interface IFnsApiClient
    {
        string GetAuthToken(string masterToken);
        ReceiptCheck CheckReceipt(string token, Receipt receipt, string appClientId);
        ReceiptDetails GetReceiptDetails(string token, Receipt receipt, string appClientId);
    }
}
