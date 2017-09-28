using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace TradingBot.Dialogs
{
    [Serializable]
    public class GreetingDialog : IDialog
    {
        async public Task StartAsync(IDialogContext context)
        {

            context.UserData.RemoveValue("userName" );
            await  context.PostAsync("Hi I am Trading Bot");
            context.Wait(GetInfoAsync);
        }

      async  private Task GetInfoAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            string userName;
            context.UserData.TryGetValue<string>("userName",out userName);
            bool getName;
            context.UserData.TryGetValue<bool>("getName", out getName);
            if (getName)
            {
                context.UserData.SetValue<bool>("getName", false);
                userName = message.Text;
                context.UserData.SetValue<string>("userName", userName);
            }

            if (!string.IsNullOrEmpty(userName))
            {
               await context.PostAsync($"What can I do for you {userName}");
            }
            else
            {
                 message = await result;
                context.UserData.SetValue<bool>("getName", true);
                await context.PostAsync("How can I refer u Sir ?");
                userName = message.Text;
                context.UserData.SetValue<string>("userName", userName);
            }
            context.Wait(GetInfoAsync);
        }
    }
}
