using Newtonsoft.Json;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
  public class GenerateChargeRequest
  {
    public long Amount { get; set; }
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
    public System.DateTime DueDate { get; set; }
    public string CustomerId { get; set; }
    public int OverdueLimit { get; set;} = 0;
    public int Fine { get; set; } = 0;
    public int Interest { get; set; } = 0;

  }
}
