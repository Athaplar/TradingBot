using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;

namespace TradingBot.Models
{
    public class OrderFactory
    {

       public  static OrderForm ParseFrom(LuisResult result)
        {
            OrderForm salesInfo = new OrderForm();
            salesInfo.Quantity = TryParseDouble(result, "sharesQuantity");
            salesInfo.Price = TryParseDouble(result, "Price");
            salesInfo.Secuirty = TryParseString(result, "Security");
            salesInfo.Action = TryParseAction(result);
            
            return salesInfo;
        }

       public static double? TryParseDouble(LuisResult result,string entity)
        {
            double? resultReturn = null;
            EntityRecommendation entityRecommendation;
            if (result.TryFindEntity(entity, out entityRecommendation))
            {
                var entiryFound = entityRecommendation.Entity;
                double doubleResult;
                 if(double.TryParse(entiryFound,out doubleResult))
                  {
                    resultReturn = doubleResult; 
                  }
            }
          return  resultReturn;
        }

        public static string TryParseString(LuisResult result, string entity)
        {
            string resultReturn = null;
            EntityRecommendation entityRecommendation;
            if (result.TryFindEntity(entity, out entityRecommendation))
            {
                var entiryFound = entityRecommendation.Entity.ToLowerInvariant();
                resultReturn = entiryFound;
            }
            return resultReturn;
        }

        public static SalesAction? TryParseAction(LuisResult result)
        {
            SalesAction? resultReturn = null;
            EntityRecommendation entityRecommendation;
            if (result.TryFindEntity("Buy", out entityRecommendation) || result.TryFindEntity("Sell", out entityRecommendation))
            {
                var entiryFound = entityRecommendation.Type;
                SalesAction parsedSalesAction;
                if(Enum.TryParse<SalesAction>(entiryFound.ToLowerInvariant(),out parsedSalesAction))
                {
                    resultReturn = parsedSalesAction;
                }
            }
            return resultReturn;
        }
    }
}
