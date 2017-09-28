using Microsoft.Bot.Builder.Luis.Models;
using System;

namespace TradingBot.Models
{

    public enum SalesAction {
        buy, sell
    }

    public enum PriceType{
        Normal, Limit, GTC
        }


    [Serializable]
    public class OrderForm
    {
        public double? Quantity { get; set; }
        public string Secuirty { get; set; }
        public SalesAction? Action { get; set; }
        public double? Price { get; set; }
        public PriceType? PriceType { get; set; }


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
