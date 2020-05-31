using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Library.DataAccess;
using WebAPI.Library.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Controlador que permite interagir com as músicas diretamente.
    /// </summary>
    [Authorize]
    public class MusicaController : ApiController
    {
        /// <summary>
        /// Retorna a música especificada pelo URI.
        /// </summary>
        /// <param name="URI">Identificador da música.</param>
        /// <returns></returns>
        public MusicaModel GetByURI(string URI)
        {
            MusicaAccess musica = new MusicaAccess();

            return musica.GetMusicaByURI(URI);
        }
       

    }
}
