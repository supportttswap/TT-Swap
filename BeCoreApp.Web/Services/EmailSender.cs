using BeCoreApp.Application.ViewModels.BotTelegram;
using BeCoreApp.Utilities.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BeCoreApp.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> TrySendEmailAsync(string email, string subject, string message)
        {
            try
            {
                _logger.LogInformation("Try to send to {0} with message:  \n{1}", email, message);
                await SendEmailAsync(email, subject, message);
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Failed to send mail with params: \nEmail: {0}, \nMessage: {1}", email, message);
                return false;
            }
        }
        public Task SendEmailAsync(string email, string subject, string message, bool isNoReply = false)
        {
            SmtpClient client = new SmtpClient(_configuration["MailSettings:Server"])
            {
                UseDefaultCredentials = false,
                Port = int.Parse(_configuration["MailSettings:Port"]),
                EnableSsl = bool.Parse(_configuration["MailSettings:EnableSsl"]),
                Credentials = new NetworkCredential(_configuration["MailSettings:UserName"], _configuration["MailSettings:Password"])
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["MailSettings:FromEmail"], _configuration["MailSettings:FromName"]),
            };
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;

            client.Send(mailMessage);
            return Task.CompletedTask;
        }

        public string BuildReportWITHDRAWMessage(WithdrawMessageParam model)
        {
            return $"{model.Email} WITHDRAW {model.Amount} {model.Currency}<br>" +
                   $"<b>User ID: TTS{model.UserId}</b><br>" +
                   $"EMAIL: <b>{model.Email}</b><br>" +
                   $"WALLET: <b>{model.Wallet}</b><br>" +
                   (model.Rate > 0 ? $"RATE: <b>${model.Rate}</b><br>" : "") +
                   $"{model.Currency} AMOUNT: {model.Amount} {model.Currency}<br>" +
                   $"Fee AMOUNT: <b>{model.Fee} {model.Currency}</b><br>" + 
                   $"<b>Submit Withdraw Time:</b> {model.WithDrawTime.ToTTSFormatTime()}<br>";
        }

        public string BuildReportDEPOSITMessage(DepositMessageParam model)
        {
            return $"{model.Email} DEPOSIT {model.Amount} {model.Currency}<br>" +
                   $"<b>User ID: TTS{model.UserId}</b><br>" +
                   $"<b>Amount {model.Currency}:</b> {model.Amount} {model.Currency}<br>" +
                   $"Address: {model.Wallet}<br>" +
                   (model.Rate > 0 ? $"RATE: <b>${model.Rate}</b><br>" : "") +
                   $"<b>Deposit Time:</b> {model.DepositeTime.ToTTSFormatTime()}<br>";
        }

        public string BuildReportCommisionMessage(ComisionMessageParam model)
        {
            return $"You have received {model.Amount} {model.Unit} from {model.AddressFrom}<br>" +
                   $"WALLET: <b>{model.AddressTo}</b><br>" +
                   (model.Rate > 0 ? $"RATE: <b>${model.Rate}</b><br>" : "") +
                   $"{model.Unit} AMOUNT: {model.Amount} {model.Unit}<br>" +
                   $"<b>Recieved at:</b> {model.RecievedAt.ToTTSFormatTime()}<br>";
        }
    }
}
