using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Strategy
{
    public interface IDeliveryType
    {
        decimal GetDeliveryInfo();
        string GetDeliveryName();
    }
}
