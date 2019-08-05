using CarServiceAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarServiceAPP.ViewModels
{
    public class Admin
    {
        public IEnumerable<CarMake> CarMakes { get; set; }]

        public IEnumerable<CarStyle> CarStyles { get; set; }

        public IEnumerable<ServiceType> ServiceTypes { get; set; }
    }
}