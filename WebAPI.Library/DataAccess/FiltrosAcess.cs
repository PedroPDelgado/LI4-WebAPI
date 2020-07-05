using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Library.Internal.DataAccess;


namespace WebAPI.Library.DataAccess
{
    public class FiltrosAcess
    {
        public List<string> ProcuraFiltro(string nome)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { Nome = nome };

            return sql.LoadData<string, dynamic>("dbo.spProcuraFiltro", parameter, "WebAPIData");
        }

    }
}
