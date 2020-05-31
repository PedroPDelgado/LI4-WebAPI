using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    /// <summary>
    /// Modelo para criar uma Sala.
    /// </summary>
    public class SalaCriacaoModel
    {
        /// <summary>
        /// Nome da Sala.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Password da Sala.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Latitude (Opcional).
        /// </summary>
        public double Xcoord { get; set; } = 91;
        /// <summary>
        /// Longitude (Opcional).
        /// </summary>
        public double Ycoord { get; set; } = 181;
        /// <summary>
        /// Limite de músicas da Sala (Opcional, default=50).
        /// </summary>
        public int LimiteMusicas { get; set; } = 50;
        /// <summary>
        /// Limite de horas de música da Sala (Opcional, default = 5).
        /// </summary>
        public int LimiteHorario { get; set; } = 5;
    }
}