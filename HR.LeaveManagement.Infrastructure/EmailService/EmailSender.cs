﻿using HR.LeaveManagement.Application.Contracts.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Models.Email
{
    internal class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get;}

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
             _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
