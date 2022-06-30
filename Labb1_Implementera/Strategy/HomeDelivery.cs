using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Strategy
{
    public class HomeDelivery : IDeliveryType
    {
        private string _deliveryType = "Home delivery";
        private decimal _deliveryPrice = 100;
        public decimal GetDeliveryInfo()
        {
            return _deliveryPrice;
        }

        public string GetDeliveryName()
        {
            return _deliveryType;
        }
    }
}
