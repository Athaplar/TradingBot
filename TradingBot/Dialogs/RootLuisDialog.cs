namespace LuisBot.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;
    using TradingBot.Models;

    [LuisModel("2bef91d7-4ca1-473e-97d2-8f5802c683fa", "8160dd0c31704b46abff4be01d58b951")]
     [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
      
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }


        [LuisIntent("SalesInfo")]
        public async Task Search(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var salesInfo = SalesInfoFactory.ParseFrom(result);
            await context.PostAsync($" Following is the form filled {salesInfo}");
          
            context.Wait(this.MessageReceived);
        }

      
    }
}
