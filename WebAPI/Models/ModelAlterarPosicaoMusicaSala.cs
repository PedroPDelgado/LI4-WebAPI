using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ModelAlterarPosicaoMusicaSala
    {
        /// <summary>
        /// Identificador da Sala.
        /// </summary>
        public int SalaId { get; set; }
        /// <summary>
        /// Identificador da música.
        /// </summary>
        public string URI { get; set; }
        /// <summary>
        /// Posição atual da música na queue.
        /// </summary>
        public int PosAtual { get; set; }
        /// <summary>
        /// Posição onde se deseja a música no final da operação de alteração na queue.
        /// </summary>
        public int PosFinal { get; set; }

    }
}