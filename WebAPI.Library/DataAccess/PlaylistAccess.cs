using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Library.Internal.DataAccess;
using WebAPI.Library.Models;

namespace WebAPI.Library.DataAccess
{
    public class PlaylistAccess
    {
        public void AdicionaMusica(int PlaylistId, string URI)
        {
            SqlDataAccess sql = new SqlDataAccess();

            PlaylistMusicaModel model = new PlaylistMusicaModel();
            model.PlaylistId = PlaylistId;
            model.MusicaURI = URI;

            sql.SaveData<PlaylistMusicaModel, dynamic>("spAdicionaMusicaPlaylist", model, "WebAPIData");
        }

        public List<MusicaModel> MusicasPlaylist(int PlaylistId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            //o nome do campo que vamos inicializar: PlaylitsId deve ser igual ao nome do parametro que a stored procedure recebe
            var p = new { PlaylistId = PlaylistId };

            return sql.LoadData<MusicaModel, dynamic>("spMusicasPlaylist", p, "WebAPIData");
        }

        public void DeleteFromPlaylist(int idPlaylist, string URI)
        {
            SqlDataAccess sql = new SqlDataAccess();

            PlaylistMusicaModel model = new PlaylistMusicaModel();
            model.PlaylistId = idPlaylist;
            model.MusicaURI = URI;

            sql.DeleteData<Tuple<int,string>,dynamic>("dbo.spRemoverMusicaPlaylistURI", model, "WebAPIData");
        }
    }
}
