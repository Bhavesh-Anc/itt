using System.Threading.Tasks;

namespace JobApplicationPortal.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}