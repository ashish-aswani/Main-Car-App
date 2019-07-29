using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarServiceAPP.Models
{
    public class CarStyle
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Style")]
        public string Style { get; set; }
    }
}