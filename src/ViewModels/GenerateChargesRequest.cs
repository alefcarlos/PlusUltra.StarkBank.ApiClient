using System.Collections.Generic;

namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class GenerateChargesRequest
    {
        public List<GenerateChargeRequest> Charges { get; set; } = new List<GenerateChargeRequest>();
    }
}