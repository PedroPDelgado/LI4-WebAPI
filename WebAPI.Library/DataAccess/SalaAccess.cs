using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Library.Internal.DataAccess;
using WebAPI.Library.Models;

namespace WebAPI.Library.DataAccess
{
    public class SalaAccess
    {
        public void EntraSala(string userId, int salaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            UserSalaModel model = new UserSalaModel();
            model.UserId = userId;
            model.SalaId = salaId;

            sql.SaveData<Tuple<string,int>, dynamic>("dbo.spEntraSala", model, "WebAPIData");

        }
    }
}
