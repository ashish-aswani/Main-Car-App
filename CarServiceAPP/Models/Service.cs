using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarServiceAPP.Models
{
	public class Service
	{
		public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is Mandatory")]
        [RegularExpression(@"^(?:0|[1-9]\d*)(?:\.(?!.*000)\d+)?$", ErrorMessage = "Enter Price in Indian Rupees")]
        [Display(Name = "Amount Paid")]
        public double Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Km's is Mandatory")]
        [RegularExpression(@"(0|([1-9][0-9]*))(\\.[0-9]+)?$", ErrorMessage = "Enter Km's in valid format")]
        [Display(Name = "Km's")]
        public int Miles { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date is Mandatory")]
        //[RegularExpression(@"^((0|1)\d{1})-((0|1|2)\d{1})-((19|20)\d{2})", ErrorMessage = "Enter Date in valid format")]
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