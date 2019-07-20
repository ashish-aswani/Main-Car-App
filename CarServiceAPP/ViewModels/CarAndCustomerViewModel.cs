using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceAPP.ViewModels
{
	public class CarAndCustomerViewModel
	{
		public IEnumerable<Customer> Customers { get; set; }
		public IEnumerable<Car> Cars { get; set; }

	}
}