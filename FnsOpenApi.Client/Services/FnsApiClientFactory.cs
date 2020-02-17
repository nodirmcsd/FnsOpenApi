using FnsOpenApi.Client.Interfaces;

namespace FnsOpenApi.Client.Services
{
    public class FnsApiClientFactory
    {
        public static IFnsApiClient CreateClient()
        {
            return new FnsApiClient(new OpenApiClient(new LogWriter()));
        }
    }
}