using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Strategy
{
    public class WarehousePickup : IDeliveryType
    {
        private string _deliveryType = "Pick up at warehouse";
        public decimal GetDeliveryInfo()
        {
            return 0;
        }

        public string GetDeliveryName()
        {
            return _deliveryType;
        }
    }
}
