using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Institutional.WebComponents {
	
	public class SendMail {

		#region Fields

		private static SmtpClient mailClient = null;

        public static SmtpClient MailClient {
            get {
                if (mailClient == null) {
                    string server = ConfigurationManager.AppSettings["SmtpClient"];
                    if (!string.IsNullOrEmpty(server)) {
                        mailClient = new SmtpClient(server);
                    } else {
                        mailClient = new SmtpClient("localhost");
                    }
                }
                return mailClient;
            }
        }

		#endregion

		#region Public

		public static void Send( string[] to, string from, string subject, string body ) {
			using( MailMessage message = new MailMessage() ) {
				message.From = new MailAddress(from);
				message.Subject = subject;
				message.Body = body;

				foreach( string mail in to ) {
					message.To.Add(new MailAddress(mail));
				}

                MailClient.Send(message);
			}
		}
		
		public static void Send( string[] to, string from, string subject, string body, bool isHtml ) {
			using( MailMessage message = new MailMessage() ) {
				message.From = new MailAddress(from);
				message.Subject = subject;
				message.Body = body;
                message.IsBodyHtml = isHtml;

				foreach( string mail in to ) {
					message.To.Add(new MailAddress(mail));
				}

                MailClient.Send(message);
			}
		}

		public static void Send( string to, string from, string subject, string body) {
			using( MailMessage message = new MailMessage( from, to, subject, body ) ) {
				message.IsBodyHtml = true;
                MailClient.Send(message);
			}
		}
		
		public static void Send( string to, string from, string subject, string body, params object[] param ) {
			Send( to, from, subject, string.Format( body, param ) );
		}

		#endregion
	}

}
