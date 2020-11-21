using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Vendor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double CommisonRate { get; set; }
        public decimal PaymenDue { get; set; }
        public string Display
        {
            get
            {
                return string.Format("{0} {1} - {2:C2}", FirstName, LastName, PaymenDue);
            }
        }

        public Vendor()
        {
            CommisonRate = .5;
        }
    }
}
