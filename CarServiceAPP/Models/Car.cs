using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarServiceAPP.Models
{
	public class Car
	{
		public int Id { get; set; }

		[Required]
		public string VIN { get; set; }

		[Required]
		public string Make { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public string Style { get; set; }

		[Required]
		public int Year { get; set; }

		public string ApplicationUserId { get; set; }

		[ForeignKey("ApplicationUserId")]
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}