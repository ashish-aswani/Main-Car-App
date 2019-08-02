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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Registration Number is Mandatory")]
        //[RegularExpression(@"^[A-Z]{2}[ -][0-9]{1,2}(?: [A-Z])?(?: [A-Z]*)? [0-9]{4}$", ErrorMessage = "Enter valid Registration Number")]
        [Display(Name ="Registration Number")]
        public string VIN { get; set; }

		[Required]
		public string Make { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public string Style { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Year is Mandatory")]
        //[RegularExpression(@"^(19[5-9]\d|20[0-4]\d|2050)$", ErrorMessage = "Enter valid year")]
        public int Year { get; set; }

		public string ApplicationUserId { get; set; }

		[ForeignKey("ApplicationUserId")]
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}