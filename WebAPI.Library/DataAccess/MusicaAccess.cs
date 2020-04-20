using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Library.Internal.DataAccess;
using WebAPI.Library.Models;

namespace WebAPI.Library.DataAccess
{
    public class MusicaAccess
    {
        public MusicaModel GetMusicaByURI(string URI)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Uri = URI };

            MusicaModel musica = sql.LoadData<MusicaModel, dynamic>("dbo.spMusicaInfo", p, "WebAPIData").FirstOrDefault();

            musica.Artistas = sql.LoadData<string, dynamic>("dbo.spArtistasMusica", p, "WebAPIData");

            return musica;
        }
    }
}
