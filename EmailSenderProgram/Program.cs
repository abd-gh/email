using System;
using System.Collections.Generic;
using System.Net;

namespace EmailSenderProgram
{
	internal class Program
	{
		private static void Main(string[] args)
		{   
			//Welcome mail,	
			Console.WriteLine("Send Welcome mail:");
			//Create object from MailTypes class
			MailTypes mailTypes = new MailTypes();

			//call properties and assign a value To add it to my mail 
			mailTypes.Subject = "Welcome as a new customer at EO!";
			mailTypes.From = new System.Net.Mail.MailAddress("info@EO.com").ToString();
			mailTypes.Body =	"<br>We would like to welcome you as customer on our site!" +
								"<br><br>Best Regards," +
								"<br>EO Team";
			bool DoEmailWorkSuccess = mailTypes.DoEmailWork();



			//Welcome Back mail,
			Console.WriteLine("Send Come back mail:");
			//call properties and assign a value To add it to my mail
			string Voucher = "EOComebackToUs";
			mailTypes.Subject = "We miss you as a customer";
			mailTypes.From = new System.Net.Mail.MailAddress("infor@EO.com").ToString();
			mailTypes.Body =     "<br>We miss you as a customer. Our shop is filled with nice products. " +
                                 "Here is a voucher that gives you 50 kr to shop for." +
								 "<br>Voucher: " + Voucher +
								 "<br><br>Best Regards,<br>EO Team";
			bool DoEmailWork2Success = mailTypes.DoEmailWork2();


			//Check if the sending went OK
			if (DoEmailWork2Success == true && DoEmailWorkSuccess== true)
			{
				Console.WriteLine("All mails are sent, I hope...\n");
			}
			//Check if the sending was not going well...
			else if(DoEmailWork2Success == true && DoEmailWorkSuccess == false)
			{
				Console.WriteLine("Oops, something went wrong when sending Welcome Back mail ");
			}else if(DoEmailWork2Success == false && DoEmailWork2Success == true)
			{
				Console.WriteLine("Oops, something went wrong when sending Welcome mail ");
            }
            else
            {
				Console.WriteLine("Oops, something went wrong when sending Welcome mail and Welcome Back mail ");
			}
			Console.ReadKey();
		}	
	}
}