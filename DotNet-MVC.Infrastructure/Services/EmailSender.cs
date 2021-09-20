using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace DotNet_MVC.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}