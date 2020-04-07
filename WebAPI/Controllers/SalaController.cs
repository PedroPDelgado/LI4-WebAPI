using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPI.Library.DataAccess;
using WebAPI.Library.Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Sala")]
    public class SalaController : ApiController
    {
        [Route("Criar")]
        //POST: criar uma sala
        public int PostCriar(NomePasswordModel model)
        {
            SalaAccess sala = new SalaAccess();

            SalaUserNomePasswordModel smodel = new SalaUserNomePasswordModel();

            smodel.UserId = RequestContext.Principal.Identity.GetUserId();
            smodel.Nome = model.Nome;
            smodel.Password = model.Password;

            return sala.CriaSala(smodel);
        }

        [Route("Eliminar")]
        //DELETE: apaga uma sala
        public void DeleteApagar(int SalaId)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.ApagaSala(SalaId, userId);
        }

        [Route("Entrar")]
        //Post: entra numa sala
        public int PostEntrar(NomePasswordModel model)
        {
            SalaAccess sala = new SalaAccess();

            SalaUserNomePasswordModel smodel = new SalaUserNomePasswordModel();

            smodel.UserId = RequestContext.Principal.Identity.GetUserId();
            smodel.Nome = model.Nome;
            smodel.Password = model.Password;

            return sala.EntraSala(smodel);
        }

        [Route("Sair")]
        //DELETE: sair de uma sala
        public void DeleteSair(int SalaId)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.SaiSala(userId, SalaId);
        }

        [Route("Procurar")]
        //GET: Listar as Salas
        public List<string> Get()
        {
            //TODO: alterar return para List<Sala___View___Model> -> adicionar mais info às salas

            SalaAccess sala = new SalaAccess();

            return sala.Procurar();
        }

        [Route("Musicas/Lista")]
        //GET: listar musicas de uma sala
        public List<MusicaModel> GetMusicas(int SalaId)
        {
            SalaAccess sala = new SalaAccess();

            return sala.GetMusicasSala(SalaId);

        }
        [Route("Musicas/Adicionar")]
        //POST: adiciona Musica a Sala
        public void PostMusica(int SalaId, string URI, string Nome, int Duracao)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.AdicionaMusicaSala(SalaId, URI, Nome, Duracao, userId);
        }

        [Route("Musicas/Remover")]
        //DELETE: apagar uma musica
        public void DeleteMusica(int SalaId, string URI)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.RemoveMusicaSala(SalaId, URI, userId);
        }

        [Route("Users")]
        //GET: Listar os users da sala
        public List<string> GetUsers(int SalaId)

        {
            using (var context = new ApplicationDbContext())
            {

                List<string> res = new List<string>();

                SalaAccess sala = new SalaAccess();

                List<string> userIds = sala.GetUsersSala(SalaId);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                foreach (string id in userIds)
                {
                    res.Add(userManager.FindById(id).UserName);
                }

                return res;
            }
        }

        [Route("Filtros/Lista")]
        //GET: devolve os filtros de uma sala
        public List<string> GetFiltros(int SalaId)
        {
            SalaAccess sala = new SalaAccess();

            return sala.GetFiltros(SalaId);
        }

        [Route("Filtros/Alterar")]
        //POST: Altera os filtros de uma sala
        public void PostFiltros(int SalaId, List<string> filtros)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.AlteraFiltros(SalaId, userId, filtros);
        }

    }
}
