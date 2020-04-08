using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SalaCriacaoModel
    {
        public string Nome { get; set; }
        public string Password { get; set; }
        public double Xcoord { get; set; }
        public double Ycoord { get; set; }
    }
}