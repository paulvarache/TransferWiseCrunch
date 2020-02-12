using Microsoft.Azure.WebJobs;
using SendGrid.Helpers.Mail;
using Transferwise.Models;
using Transferwise.Utilities;

namespace Functions
{
    public static class Notify
    {
        private static EnvVars EnvData = EnvVars.FromEnv();
        [FunctionName("Notify")]
        public static void Run(
    [ServiceBusTrigger("%EMAIL_BUS_NAME%")] Notification state,
    [SendGrid()] out SendGridMessage message)
        {
            message = new SendGridMessage();
            message.AddTo("varache.paul@gmail.com");
            message.AddContent("text/html", $"<h2>Just spent {state.Amount} using Transferwise</h2>");
            message.SetFrom(new EmailAddress("dev@paulvarache.co.uk"));
            message.SetSubject("Transferwise Watcher report");
        }
    }
}