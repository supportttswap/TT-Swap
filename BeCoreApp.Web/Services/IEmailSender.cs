using BeCoreApp.Application.ViewModels.BotTelegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, bool isNoReply = false);
        Task<bool> TrySendEmailAsync(string email, string subject, string message);
        string BuildReportWITHDRAWMessage(WithdrawMessageParam model);
        string BuildReportDEPOSITMessage(DepositMessageParam model);
        string BuildReportCommisionMessage(ComisionMessageParam model);
    }
}
