using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Singelton
{
    public sealed class UserInformation
    {

        private static UserInformation _instance;

        private UserInformation()
        {
            
        }


        public static UserInformation Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserInformation();
                }
                return _instance;
            }
            
        }

        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
