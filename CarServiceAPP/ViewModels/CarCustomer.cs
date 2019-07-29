using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceAPP.ViewModels
{
    public class CarCustomer
    {
        public Customer Customers { get; set; }
        public Car Cars { get; set; }

        public IEnumerable<CarMake> CarMakes { get; set; }

        public IEnumerable<CarStyle> CarStyles  { get; set; }
    }
}