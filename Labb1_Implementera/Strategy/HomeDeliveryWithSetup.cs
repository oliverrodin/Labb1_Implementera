using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Strategy
{
    public class HomeDeliveryWithSetup : IDeliveryType
    {
        private string _deliveryType = "Home delivery with setup";
        private decimal _deliveryPrice = 100;
        private decimal _setupPrice = 250;

        public decimal GetDeliveryInfo()
        {
            return _deliveryPrice + _setupPrice;
        }

        public string GetDeliveryName()
        {
            return _deliveryType;
        }
    }
}
