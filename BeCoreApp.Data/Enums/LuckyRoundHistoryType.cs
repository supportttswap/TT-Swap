using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum LuckyRoundHistoryType
    {
        [Description("Pay Lucky Round")]
        PayLuckyRound = 1,
        [Description("Win 50 TT-SWAP")]
        Win50TTS = 2,
        [Description("Win 500 TT-SWAP")]
        Win500TTS = 3,
        [Description("Win 1000 TT-SWAP")]
        Win1000TTS = 4,
        [Description("Win 3000 TT-SWAP")]
        Win3000TTS = 5,
        [Description("Good Luck")]
        GoodLuck = 6,
        [Description("Win 5000 TT-SWAP")]
        Win5000TTS = 7,
        [Description("Win Ticket")]
        WinTicket = 8,
        [Description("Win 0.5 BNB")]
        Win05BNB = 9
    }
}
