using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class NomePasswordModel
    {
        /// <summary>
        /// Nome da Sala.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Password da Sala.
        /// </summary>
        public string Password { get; set; }
    }
}