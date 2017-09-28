using Microsoft.Bot.Builder.Luis.Models;
using System;

namespace TradingBot.Models
{

   public enum SalesAction{
        buy,sell
    }

    [Serializable]
    public class SalesInfo
    {
        public double? Quantity { get; set; }
        public string Secuirty { get; set; }
        public SalesAction? Action { get; set; }
        public double? Price { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"\n Quantity: {Quantity ?? double.NaN} \n Security: {Secuirty??string.Empty} \n Price: {Price ?? double.NaN} \n Action: {Action}";
        }
    }

  
}
