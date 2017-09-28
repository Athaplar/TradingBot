using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingBot.Dialogs
{
   
    [LuisModel("2bef91d7-4ca1-473e-97d2-8f5802c683fa", "8160dd0c31704b46abff4be01d58b951")]
    [Serializable]
    public class LuisDIalog:LuisDialog<object>
    {

        [LuisIntent("")]
        async public Task None(IDialogContext context,LuisRequest result)
        {
            Console.WriteLine("Got here");
        }

        [LuisIntent("SalesInfo")]
        async public Task SalesInfo(IDialogContext context, LuisRequest result)
        {
            Console.WriteLine("Got here");
        }
    }
}
