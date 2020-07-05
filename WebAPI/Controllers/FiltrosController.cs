using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Library.Internal.DataAccess;
using WebAPI.Library.DataAccess;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Filtros")]
    public class FiltrosController : ApiController
    {
        // GET: Filtros
        public List<string> GetProcuraFiltro(string Nome)
        {
            FiltrosAcess filtros = new FiltrosAcess();

            return filtros.ProcuraFiltro(Nome);
        }

    }
}
