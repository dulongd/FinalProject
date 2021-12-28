﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FinalProject.Service
{
    public class EmailSender : IEmailSender { 
        public EmailOptions Options { get; set; }
    
        public EmailSender(IOptions<EmailOptions> emailoptions)
        {
          Options = emailoptions.Value;
        }
        public Task SendEmailAsync(string email, string subject,string message)
        {
            return Excute(Options.SendGridKey, subject, message, email);
        }

        private async Task Excute(string sendGridKey, string subject, string message, string email)
        {
           
            var client = new SendGridClient(sendGridKey);
            var from = new EmailAddress("kavithaa434@gmail.com", "Example User");
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = message;
            var htmlContent = "<strong>" + message + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
