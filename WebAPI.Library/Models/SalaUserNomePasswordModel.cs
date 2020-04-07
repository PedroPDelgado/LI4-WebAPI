using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Library.Models
{
    public class SalaUserNomePasswordModel
    {
        public int SalaId { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
    }
}
