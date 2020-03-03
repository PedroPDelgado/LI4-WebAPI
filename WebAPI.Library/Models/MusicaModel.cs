using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Library.Models
{
    public class MusicaModel
    {
        public string Id { get; set; }
        public string URI { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
        public int Duracao_ms { get; set; }
    }
}
