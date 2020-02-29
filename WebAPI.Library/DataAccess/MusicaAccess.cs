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
        public List<MusicaModel> GetMusicaById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output = sql.LoadData<MusicaModel, dynamic>("dbo.spMusicaInfo", p, "WebAPIData");

            return output;
        }
    }
}
