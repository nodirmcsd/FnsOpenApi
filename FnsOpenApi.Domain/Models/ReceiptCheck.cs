namespace FnsOpenApi.Domain.Models
{
    /// <summary>
    /// Результат проверки чека
    /// </summary>
    public class ReceiptCheck
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
    }
}