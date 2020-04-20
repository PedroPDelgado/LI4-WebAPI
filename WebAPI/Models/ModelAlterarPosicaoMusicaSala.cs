using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ModelAlterarPosicaoMusicaSala
    {
        public int SalaId { get; set; }
        public string URI { get; set; }
        public int PosAtual { get; set; }
        public int PosFinal { get; set; }

    }
}