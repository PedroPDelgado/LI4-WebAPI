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
        public List<MusicaModel> GetMusicaByURI(string URI)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Uri = URI };

            return sql.LoadData<MusicaModel, dynamic>("dbo.spMusicaInfo", p, "WebAPIData");

        }
    }
}
