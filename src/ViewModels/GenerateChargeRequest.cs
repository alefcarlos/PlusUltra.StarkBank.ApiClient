namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class GenerateChargeRequest
    {
        public long Amount { get; set; }
        public System.DateTime DueDate { get; set; }
        public string CustomerId { get; set; }
    }
}