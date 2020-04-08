using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Library.Models
{
    public class SalaCriarModel
    {
        public int SalaId { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public double Xcoord { get; set; }
        public double Ycoord { get; set; }
    }
}
