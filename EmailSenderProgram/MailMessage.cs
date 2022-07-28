using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram
{
    public class MailMessage
    {
        public bool SendMessage(string To, string Subject, string From, string Body)
        {
            try
            {
				//Create a new MailMessage
				System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
				//Add customer to reciever list
				Message.To.Add(To);
				//Add subject
				Message.Subject = Subject;
				//Send mail from info@EO.com
				Message.From = new System.Net.Mail.MailAddress(From);
				//Add body to mail
				Message.Body = Body;
				Console.WriteLine("Send mail to:" + To);
				//All mails are sent! Success!
				return true;
			}catch(Exception ex)
            {
				//Something went wrong :(
				Console.WriteLine("There are something wrong when sending mail to " +To);
				Console.WriteLine(ex.Message);
				return false;
            }
		
		}
    }
}


//Create a SmtpClient to our smtphost: yoursmtphost
//System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("yoursmtphost");
//Create the host.
//smtp.Host = "stmp.EO.com";
//Create the port 587 or 465
//smtp.Port = 587;
//smtp.UseDefaultCredentials = false;
//Enablessl use to encrypt the connection to make it safe
//smtp.EnableSsl = true;

//use network Credential to access my email
//NetworkCredential ns = new NetworkCredential(from,password);
//smtp.Credentials = ns;
//Send mail
//smtp.Send(Message);
//Don't send mails in debug mode, just write the emails in console
//Console.WriteLine("Send mail to:" + ourCustomer[i].Email);