using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Strategy
{
    public class DeliveryContext
    {
        private IDeliveryType _type;

        public DeliveryContext()
        {
            
        }

        public DeliveryContext(IDeliveryType type)
        {
            _type = type;
        }

        public void SetDeliveryType(IDeliveryType type)
        {
            _type = type;
        }

        public decimal GetDeliveryCost()
        {
           return _type.GetDeliveryInfo();
        }

        public string GetDelivaryType()
        {
            return _type.GetDeliveryName();
        }
    }
}
