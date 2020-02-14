using FnsOpenApi.Domain.Interfaces;

namespace FnsOpenApi.Services
{
    public class FnsApiClientFactory
    {
        public static IFnsApiClient CreateClient()
        {
            return new FnsApiClient(new OpenApiClient(new LogWriter()));
        }
    }
}