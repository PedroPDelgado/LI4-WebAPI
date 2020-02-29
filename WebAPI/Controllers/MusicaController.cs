using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Library.DataAccess;
using WebAPI.Library.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    public class MusicaController : ApiController
    {
        public List<MusicaModel> GetById(int id)
        {
            MusicaAccess musica = new MusicaAccess();

            return musica.GetMusicaById(id);
        }

       
    }
}
