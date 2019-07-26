using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServiceAPP.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required]
        [Display (Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public long Mobile { get; set; }

	}
}