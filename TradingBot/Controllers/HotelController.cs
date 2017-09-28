using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.AspNetCore.Mvc;
using System;
using TradingBot.Dialogs;
using LuisBot.Dialogs;

namespace TradingBot.Controllers
{   
    
    [Route("api/[controller]")]
    [BotAuthentication]
    public class TradingController: Controller
    {
       [HttpPost]
       async public Task<HttpResponseMessage> Post([FromBody]Activity message)
        {
            if(message.Type == ActivityTypes.Message)
            {
                /* ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
                 int? length = (message.Text ?? string.Empty).Length;
                 Activity reply = message.CreateReply($" Hey I am hotel bot. Btw ur text was {length}");
                 await connector.Conversations.ReplyToActivityAsync(reply);
                 */
                // await Conversation.SendAsync(message, () => new GreetingDialog());
                //await Conversation.SendAsync(message, () => new LuisDIalog());
                await Conversation.SendAsync(message, () => new RootLuisDialog());
            }
            else
            {
                HandleOtherMessage(message);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private void HandleOtherMessage(Activity message)
        {
            throw new NotImplementedException();
        }
    }
}
