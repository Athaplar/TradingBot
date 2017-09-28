using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;

namespace TradingBot.Models
{
    public class SalesInfoFactory
    {

       public  static SalesInfo ParseFrom(LuisResult result)
        {
            SalesInfo salesInfo = new SalesInfo();
            salesInfo.Quantity = TryParseDouble(result, "sharesQuantity");
            salesInfo.Price = TryParseDouble(result, "Price");
            salesInfo.Secuirty = TryParseString(result, "Security");
            //salesInfo.Action =  Enum.tTryParseString()
            SalesAction action;
            if(Enum.TryParse<SalesAction>(TryParseString(result, "Action"),out action))
            {
                salesInfo.Action = action;
            }
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

        public static string TryParseEnum(LuisResult result, string entity)
        {
            string resultReturn = null;
            EntityRecommendation entityRecommendation;
            if (result.TryFindEntity(entity, out entityRecommendation))
            {
                var entiryFound = entityRecommendation.Entity;
                resultReturn = entiryFound;
            }
            return resultReturn;
        }
    }
}
