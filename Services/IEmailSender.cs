using System.Threading.Tasks;

namespace scheduler.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
