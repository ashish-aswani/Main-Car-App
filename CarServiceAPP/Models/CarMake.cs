using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServiceAPP.Models
{
    public class CarMake
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Make")]
        public string  Make { get; set; }
    }
}