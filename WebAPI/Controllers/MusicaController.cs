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
        public MusicaModel GetById(string URI)
        {
            MusicaAccess musica = new MusicaAccess();

            return musica.GetMusicaByURI(URI).FirstOrDefault();
        }
        
        public void SaveMusica(string uri, string nome, string artista, string genero, int duracao)
        {
            MusicaModel model = new MusicaModel();
            model.URI = uri;
            model.Nome = nome;
            model.Artista = artista;
            model.Genero = genero;
            model.Duracao_ms = duracao;

            MusicaAccess musica = new MusicaAccess();

            musica.InsertMusica(model);
        }
       

    }
}
