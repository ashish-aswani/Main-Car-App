using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static CarServiceAPP.Models.EnumMakeStyleAndServiceType;

namespace CarServiceAPP.Models
{
	public class Service
	{
		public int Id { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		public int Miles { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

		public int CarId { get; set; }

		[ForeignKey("CarId")]
		public virtual Car Car { get; set; }

		[Required]
        [Display(Name = "Service Type")]
        public string ServiceType { get; set; }

	}
}