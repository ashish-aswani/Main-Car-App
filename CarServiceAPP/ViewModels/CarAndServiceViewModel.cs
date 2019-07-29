using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceAPP.ViewModels
{
	public class CarAndServiceViewModel
	{
        public Car Cars { get; set; }
        public IEnumerable<Service> Services { get; set; }

        public Service Service { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
    }
}