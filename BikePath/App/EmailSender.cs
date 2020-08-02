using System;
using System.Net;
using System.Net.Mail;

namespace BikePath
{
    public class EmailSender
    {
        // this is open data becouse this app will never be used as real project :)

        private const string BIKE_PATH_EMAIL = "bike.path.verify@gmail.com";
        private const string BIKE_PATH_PASSWORD = "1234509876_Bikepath";
        private const string NAME = "Bike Path";

        private const string SMTP_SERVER = "smtp.gmail.com";
        private const short SMTP_PORT = 587;

        private const short CODE_DIFFICULT = 6; // length verify code
        public string VERIFY_CODE { get; private set; }

        public void SendVerifyCode(string email)
        {
            MailAddress from = new MailAddress(BIKE_PATH_EMAIL, NAME);
            MailAddress to = new MailAddress(email);

            VERIFY_CODE = GenerateCode();
            MailMessage message = CreateMessage(from, to);
            SmtpClient smtp = CreateSmtpClient();

            smtp.Send(message);
        }

        private string GenerateCode()
        {
            string code = string.Empty;

            Random random = new Random();
            for (int i = 0; i < CODE_DIFFICULT; i++)
            {
                code += random.Next(0, 10).ToString();
            }

            return code;
        }

        private MailMessage CreateMessage(MailAddress from, MailAddress to)
        {
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Код подтверждения Bike Path";
            message.Body = "<h1>" + VERIFY_CODE + "</h1>";
            message.IsBodyHtml = true;

            return message;
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtp = new SmtpClient(SMTP_SERVER, SMTP_PORT);
            smtp.Credentials = new NetworkCredential(BIKE_PATH_EMAIL, BIKE_PATH_PASSWORD);
            smtp.EnableSsl = true;

            return smtp;
        }
    }
}
