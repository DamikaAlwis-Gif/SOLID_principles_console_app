using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Net;
using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;


namespace ConsoleApp3
{
    internal class EmailOperations : IReminderOperations

    {

        private String from = "nuswarwick@gmail.com";
        private String password = "xpbpjfnqjkzlqmzy";
        public void Send(AReminder reminder)
        {
          

            // SMTP server details for Gmail
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;

            using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(from, password);
                smtpClient.EnableSsl = true;
                MailMessage mailMessage = new MailMessage(from, reminder.To, reminder.Subject, reminder.Content);

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Email sent successfully!" + DateTime.Today );
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }

        }
    }
}
