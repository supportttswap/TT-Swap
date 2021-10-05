using BeCoreApp.Application.Implementation;
using BeCoreApp.Application.ViewModels.BotTelegram;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BeCoreApp.Application.Interfaces
{
    public interface IBotTelegramService
    {
        Task<bool> TrySendMessageAsync(ITelegramBotClient botClient, string message, ChatId chatId = null, long? groupIndentify = null);
        Task SendMessageAsync(ITelegramBotClient botClient,string message, ChatId chatId = null, long? groupIndentify = null);
        Task SendMessageAsyncWithSendingBalance(ActionType type, string message, ChatId chatId = null, long? groupIndentify = null);
        string BuildReportDEPOSITMessage(DepositMessageParam model);
        string BuildReportWITHDRAWMessage(WithdrawMessageParam model);
        string BuildReportDepositPresaleMessage(PresaleMessageParam model);
        string BuildReportReceivePresaleMessage(PresaleMessageParam model);
    }
}
