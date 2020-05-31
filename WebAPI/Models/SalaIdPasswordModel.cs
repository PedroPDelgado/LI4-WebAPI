using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SalaIdPasswordModel
    {
        /// <summary>
        /// Identificador da Sala.
        /// </summary>
        public int SalaId { get; set; }
        /// <summary>
        /// Nova password da Sala.
        /// </summary>
        public string Password { get; set; }
    }
}