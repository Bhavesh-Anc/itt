namespace JobApplicationPortal.Services
{
    public class SendGridOptions
    {
        public string ApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}