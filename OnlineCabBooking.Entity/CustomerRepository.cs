using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCabBooking.Entity
{
    public class CustomerRepository
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string mail { get; set; }
        public long mobile { get; set; } 
        public string password { get; set; }
        public string location { get; set; }
    }
}
