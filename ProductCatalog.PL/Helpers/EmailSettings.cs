
using System.Net;
using System.Net.Mail;

namespace Product_Catalog.PL.Helpers
{
	public class EmailSettings
	{
		public static void SendEmail(Email email)
		{

			var client = new SmtpClient("smtp.gamil.com", 587);
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential("", "");
			
			client.Send("", email.To, email.Subject, email.Body);

		}
	}
}
