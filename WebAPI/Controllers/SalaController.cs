using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Library.DataAccess;

namespace WebAPI.Controllers
{
    [Authorize]
    public class SalaController : ApiController
    {
        public void EntraSala(int SalaId)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.EntraSala(userId, SalaId);
        }
    }
}
