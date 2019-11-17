namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class StarkBankAuthRequest
    {
        public string Workspace { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string Platform => "api";
    }
}