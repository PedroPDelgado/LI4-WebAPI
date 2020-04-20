using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Library.Models
{
    public class MusicaModel
    {
        public string URI { get; set; }
        public string Nome { get; set; }
        public int Duracao_ms { get; set; }
        public string Album { get; set; }
        public string Url_imagem { get; set; }
        public List<string> Artistas { get; set; }

    }
}
