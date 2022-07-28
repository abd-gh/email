using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram
{
	public class Mail
	{
        public string From { get; set; }
		public string Body { get; set; }
		public string Subject { get; set; }
		//List all customers 
		public List<Customer> customers = DataLayer.ListCustomers();
		//List all orders
		public List<Order> orders = DataLayer.ListOrders();
	}
	public class MailTypes:Mail
    {
		//List all customers 
		//List<Customer> customers = DataLayer.ListCustomers();
		//List all orders
		//List<Order> orders = DataLayer.ListOrders();
		
		
		public bool DoEmailWork()
		{
			MailMessage mailMessage = new MailMessage();
			//to check if programm send to all email
			bool success = true;
			//to check if send mail for every email success
			bool check = true;
			//loop through list of new customers
			for (int i = 0; i < customers.Count; i++)
			{			
					if (customers[i].CreatedDateTime > DateTime.Now.AddDays(-1))
					{
						//add customer email in body of mail
						Body = "Hi " + customers[i].Email + Body;
					    check = mailMessage.SendMessage(customers[i].Email, Subject, From, Body);
						if (check == false)
						{						
							success= false;
						}	
				    }              
			}						
			return success;
		}

		public bool DoEmailWork2()
		{
				//to check if programm send to all email
				bool success = true;
				//loop through list of customers
				foreach (Customer customer in customers)
				{					
					// We send mail if customer hasn't put an order
					bool Send = true;
					//loop through list of orders to see if customer don't exist in that list
					foreach (Order order in orders)
					{
						// Email exists in order list
						if (customer.Email == order.CustomerEmail)
						{
							//We don't send email to that customer
							Send = false;
						}
					}
					//Send if customer hasn't put order
					if (Send == true)
					{
					    // create object from mail message 
						MailMessage mailMessage = new MailMessage();
						//to check if send mail for every email success
						bool check = true;
						//add customer email in body of mail
						Body = "Hi " + customer.Email + Body;
						
						check = mailMessage.SendMessage(customer.Email, Subject, From, Body);
						if (check == false)
						{							
							success = false;
						}
					}
				}				
				return success;
		}
	}
}
