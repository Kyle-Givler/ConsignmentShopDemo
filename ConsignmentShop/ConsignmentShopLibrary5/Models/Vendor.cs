using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double CommisonRate { get; set; }
        public decimal PaymentDue { get; set; }
        public string Display
        {
            get
            {
                return string.Format("{0} {1} - {2:C2}", FirstName, LastName, PaymentDue);
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Vendor()
        {
            CommisonRate = .5;
        }
    }
}
