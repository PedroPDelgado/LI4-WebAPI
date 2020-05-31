using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SalaIdNomeModel
    {
        /// <summary>
        /// Identificador da Sala.
        /// </summary>
        public int SalaId { get; set; }
        /// <summary>
        /// Novo nome da Sala.
        /// </summary>
        public string Nome { get; set; }
    }
}