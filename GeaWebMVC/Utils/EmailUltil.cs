using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GeaWebMVC.Utils
{
    public static class EmailUlts
    {
        public static void SendEmail(MailMessage email)
        {

            try
            {
                
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpEmail"].ToString());

                // set smtp-client with basicAuthentication
                smtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                          System.Net.NetworkCredential(ConfigurationManager.AppSettings["usernameEmail"].ToString() ,
                          ConfigurationManager.AppSettings["passwordEmail"].ToString());

                smtpClient.Credentials = basicAuthenticationInfo;

                email.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"].ToString(),
                        ConfigurationManager.AppSettings["NameFromEmail"].ToString());

                smtpClient.Send(email);
            }
            catch (SmtpException ex)
            {
                throw new ApplicationException("Ocorreu um erro com servidor SMTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}