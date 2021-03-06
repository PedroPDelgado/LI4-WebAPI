﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SalaIdUsernameModel
    {
        /// <summary>
        /// Identificador da Sala.
        /// </summary>
        public int SalaId { get; set; }
        /// <summary>
        /// Username do utilizador.
        /// </summary>
        public string Username { get; set; }
    }
}