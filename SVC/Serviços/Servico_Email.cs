using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Servico_Email
    {
        public void EnviarEmail(string assunto, string corpo, List<string> lstEmailDestino)
        {
            SmtpSection smtpSection = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;

            MailMessage email = new MailMessage();

            lstEmailDestino.ForEach(emailDestino =>
            {
                email.To.Add(new MailAddress(emailDestino));
            });

            email.From = new MailAddress("onesistema@gmail.com", "One Sistema");
            email.Subject = assunto;
            email.Body = corpo;
            email.Priority = MailPriority.High;
            email.IsBodyHtml = false;

            SmtpClient client = new SmtpClient();
            client.Host = smtpSection.Network.Host;
            client.Port = smtpSection.Network.Port;
            client.EnableSsl = smtpSection.Network.EnableSsl;
            client.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
            client.Credentials = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);

            try
            {
                client.Send(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
