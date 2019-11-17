namespace PlusUltra.StarkBank.ApiClient.ViewModels
{
    public class StarkBankTokenResponse
    {
        public StarkBankTokenMemberResponse Member { get; set; }
        public string AccessToken { get; set; }
    }

    public class StarkBankTokenMemberResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string WorkspaceId { get; set; }
        public string PictureUrl { get; set; }
        public string Id { get; set; }
        public string[] Permissions { get; set; }
    }
}