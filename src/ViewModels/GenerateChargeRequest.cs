using Newtonsoft.Json;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class GenerateChargeRequest
    {
        public long Amount { get; set; }
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public System.DateTime DueDate { get; set; }
        public string CustomerId { get; set; }
        public float Fine => 0;
        public float Interest => 0;
        public int Overduelimit => 0;
    }
}