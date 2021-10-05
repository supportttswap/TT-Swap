using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.BotTelegram;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BeCoreApp.Application.Implementation
{
    //this class will be enhanced later
    public class BotTelegramService : IBotTelegramService
    {
        private static List<WrapperTelegramBot> _botClientsWithdraw;
        private static List<WrapperTelegramBot> _botClientsDeposit;
        private readonly ILogger<BotTelegramService> _logger;

        public BotTelegramService(ILogger<BotTelegramService> logger)
        {
            _logger = logger;
        }

        public List<WrapperTelegramBot> GetClientBots(ActionType type)
        {
            switch (type)
            {
                case ActionType.Withdraw:
                    if (_botClientsWithdraw == null)
                    {
                        _botClientsWithdraw = Bots;
                    }

                    return _botClientsWithdraw;
                case ActionType.Deposit:
                    if (_botClientsDeposit == null)
                    {
                        _botClientsDeposit = Bots;
                    }
                    return _botClientsDeposit;

                default:
                    return null;
            }
        }

        public Task SendMessageAsyncWithSendingBalance(ActionType type, string message, ChatId chatId = null, long? groupIndentify = null)
        {
            try
            {
                return ExcuteWithFreeBotFirst(type, (bot) => TrySendMessageAsync(bot, message, chatId));

            }
            catch (Exception e)
            {
                _logger.LogError("BotTelegram: ", e);
                //ignore
                return Task.CompletedTask;
            }
        }

        public async Task<bool> TrySendMessageAsync(ITelegramBotClient botClient, string message, ChatId chatId = null, long? groupIndentify = null)
        {
            try
            {
                _logger.LogInformation("Send to Group Chat with message: {0}", message);
                await SendMessageAsync(botClient, message, chatId, groupIndentify);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to send Message: {0}", message);
                return false;
            }
        }

        public async Task SendMessageAsync(ITelegramBotClient botClient, string message, ChatId chatId = null, long? groupIndentify = null )
        {
            
            chatId = chatId ?? new ChatId(groupIndentify.Value);

            await botClient.SendChatActionAsync(chatId, ChatAction.Typing);

            await botClient.SendTextMessageAsync(chatId, message, ParseMode.Html);
        }
        public string BuildReportWITHDRAWMessage(WithdrawMessageParam model)
        {
            return $"{model.Email} WITHDRAW {model.Amount} {model.Currency}\n" +
                   $"<b>User ID: TTS{model.UserId}</b>\n" +
                   $"EMAIL: <b>{model.Email}</b>\n" +
                   $"WALLET: <b>{model.Wallet}</b>\n" +
                   (model.Rate > 0 ? $"RATE: <b>${model.Rate}</b>\n" : "") +
                   $"{model.Currency} AMOUNT: {model.Amount} {model.Currency}\n" +
                   $"Fee AMOUNT: <b>{model.Fee} {model.Currency}</b>\n" + 
                   $"<b>Sponsor ID: TTS{model.SponsorId}</b>\n" +
                   $"<b>Sponsor Email: {model.SponsorEmail}</b>\n" +
                   $"<b>Submit Withdraw Time:</b> {model.WithDrawTime.ToTTSFormatTime()}\n";
        }

        public string BuildReportDEPOSITMessage(DepositMessageParam model)
        {
            return $"{model.Email} DEPOSIT {model.Amount} {model.Currency}\n" +
                   $"<b>User ID: TTS{model.UserId}</b>\n" +
                   $"<b>Amount {model.Currency}:</b> {model.Amount} {model.Currency}\n" +
                   $"Address: {model.Wallet}\n" +
                   (model.Rate > 0 ? $"RATE: <b>${model.Rate}</b>\n" : "") +
                   $"<b>Sponsor ID: TTS{model.SponsorId}</b>\n" +
                   $"<b>Sponsor Email: {model.SponsorEmail}</b>\n" +
                   $"<b>Deposit Time:</b> {model.DepositeTime.ToTTSFormatTime()}\n";
        }

        public string BuildReportDepositPresaleMessage(PresaleMessageParam model)
        {
            return $"<b>PRESALE</b>\nUser deposit {model.AmountBNB} BNB to purchase {model.AmountTTS} TTS\n" +
                   $"<b>Amount BNB:</b> {model.AmountBNB} BNB\n" +
                   $"<b>Amount TTS:</b> {model.AmountTTS} TTS\n" +
                   $"<b>User Wallet:</b> {model.UserWallet}\n" +
                   $"<b>Receiving System Wallet:</b> {model.SystemWallet}\n" +
                   $"<b>Deposit Time:</b> {model.DepositAt.ToTTSFormatTime()}\n";
        }

        public string BuildReportReceivePresaleMessage(PresaleMessageParam model)
        {
            return $"<b>PRESALE</b>\nUser received {model.AmountTTS} TTS\n" +
                   $"<b>Amount BNB:</b> {model.AmountBNB} BNB\n" +
                   $"<b>Amount TTS:</b> {model.AmountTTS} TTS\n" +
                   $"<b>User Wallet:</b> {model.UserWallet}\n" +
                   $"<b>Sending System Wallet:</b> {model.SystemWallet}\n" +
                   $"<b>Receive Time:</b> {model.ReceivedAt.ToTTSFormatTime()}\n";
        }

        private async Task ExcuteWithFreeBotFirst(ActionType type, Func<ITelegramBotClient, Task> func)
        {
            var bots = GetClientBots(type);

            var wrapperBot = bots.OrderBy(b => b.Time).FirstOrDefault();

            await func(wrapperBot.BotClient);

            if (wrapperBot.Time == 0)
            {
                var ticks = DateTime.Now.Ticks;

                wrapperBot.FirstCallSendindMessageAt = ticks;
            }

            wrapperBot.Time++;

            ResetWrapperBots(bots);
        }

        private void ResetWrapperBots(List<WrapperTelegramBot> bots)
        {
            var ticks = DateTime.Now.Ticks;

            //if over 60s then reset bot;
            var freeBots = bots.Where(b => ticks - b.FirstCallSendindMessageAt >= 600000000 && b.Time >= 1);

            foreach (var wrapperBot in freeBots)
            {
                wrapperBot.Time = 0;
            }
        }

        private List<WrapperTelegramBot> Bots => new List<WrapperTelegramBot>
        {
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken1),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken2),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken3),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken4),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken5),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken6),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken7),
            },
            new WrapperTelegramBot
            {
                BotClient = new TelegramBotClient(CommonConstants.BotToken8),
            },
            //new WrapperTelegramBot
            //{
            //    BotClient = new TelegramBotClient(CommonConstants.BotToken9),
            //},
            //new WrapperTelegramBot
            //{
            //    BotClient = new TelegramBotClient(CommonConstants.BotToken10),
            //}
        };
    }

    public class WrapperTelegramBot
    {
        public ITelegramBotClient BotClient { get; set; }
        public int Time { get; set; }
        public long FirstCallSendindMessageAt { get; set; }
    }


    public enum ActionType
    {
        Withdraw, Deposit
    }
}
