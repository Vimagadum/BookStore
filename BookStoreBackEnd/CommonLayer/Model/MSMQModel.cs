using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using com.sun.org.apache.xerces.@internal.impl.msg;
using Experimental.System.Messaging;

namespace CommonLayer.Model
{
    public class MSMQModel
    {
        MessageQueue messageQueue = new MessageQueue();

        /// <summary>Senders the specified token.</summary>
        /// <param name="token">The token.</param>
        public void Sender(string token)
        {
            ////system private msmq server path 
            messageQueue.Path = @".\private$\Tokens";
            try
            {
                ////Checking Path is exists or Not
                if (!MessageQueue.Exists(messageQueue.Path))
                {
                    ////If path is not there then Creating Path
                    MessageQueue.Create(messageQueue.Path);
                }

                this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                ////Delegate Method
                this.messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                this.messageQueue.Send(token);
                this.messageQueue.BeginReceive();
                this.messageQueue.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>Handles the ReceiveCompleted event of the MessageQueue control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ReceiveCompletedEventArgs" /> instance containing the event data.</param>
        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var message = this.messageQueue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("vinayakmagadum031@gmail.com", "Vinu&123"),
                    EnableSsl = true
                };
                mailMessage.From = new MailAddress("vinayakmagadum031@gmail.com");
                mailMessage.To.Add(new MailAddress("vinayakmagadum031@gmail.com"));
                mailMessage.Body = token;
                mailMessage.Subject = "Bookstore App Reset Link";
                smtpClient.Send(mailMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
