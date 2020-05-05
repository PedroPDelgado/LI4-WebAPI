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
        public double Xcoord { get; set; } = 91;
        public double Ycoord { get; set; } = 181;
        public int LimiteMusicas { get; set; } = 50;
        public int LimiteHorario { get; set; } = 5;
    }
}