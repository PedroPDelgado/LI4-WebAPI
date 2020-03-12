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
    public class PlaylistController : ApiController
    {
        public List<MusicaModel> GetMusicasPlaylist(int idPlaylist)
        {
            
            PlaylistAccess playlist = new PlaylistAccess();

            return playlist.MusicasPlaylist(idPlaylist);
        }

        public void AdicionaMusica(int idPlaylist, string URI)
        {
            PlaylistAccess playlist = new PlaylistAccess();

            playlist.AdicionaMusica(idPlaylist, URI);
        }

    public void DeleteMusica(int idPlaylist, string URI)
        {
            PlaylistAccess playlist = new PlaylistAccess();

            playlist.DeleteFromPlaylist(idPlaylist, URI);
        }
    }
}
