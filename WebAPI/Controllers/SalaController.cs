using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        /* Coordenadas e Limites de Musicas/Horas sao opcionais
         */
        public HttpResponseMessage PostCriar(SalaCriacaoModel model)
        {

            if(Math.Abs(model.Xcoord) > 90 || Math.Abs(model.Ycoord) > 180)
            {
                var message = string.Format("Bad coordinates");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }
            else
            {
                SalaAccess sala = new SalaAccess();

                SalaCriarModel smodel = new SalaCriarModel();

                smodel.UserId = RequestContext.Principal.Identity.GetUserId();
                smodel.Nome = model.Nome;
                smodel.Password = model.Password;
                smodel.Xcoord = model.Xcoord;
                smodel.Ycoord = model.Ycoord;
                smodel.LimiteMusicas = model.LimiteMusicas;
                smodel.LimiteHorario = model.LimiteHorario;

                return Request.CreateResponse(HttpStatusCode.OK,sala.CriaSala(smodel));
            }
        }

        [Route("Nome/Alterar")]
        //POST: altera nome da sala
        public void PostAlterarNome(SalaIdNomeModel model)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.AlteraNome(model.SalaId, model.Nome, userId);
        }

        [Route("Password/Alterar")]
        //POST: altera password da sala
        public void PostAlterarPassword(SalaIdPasswordModel model)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.AlteraPassword(model.SalaId, model.Password, userId);
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
        public HttpResponseMessage PostEntrar(NomePasswordModel model)
        {
            SalaAccess sala = new SalaAccess();

            SalaUserNomePasswordModel smodel = new SalaUserNomePasswordModel();

            smodel.UserId = RequestContext.Principal.Identity.GetUserId();
            smodel.Nome = model.Nome;
            smodel.Password = model.Password;

            int id = sala.GetSalaId(smodel.Nome);

            if (id == 0)
            {
                var message = string.Format("There isn't a queue with the name {0}.",smodel.Nome);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            else
            {
                if(sala.VerificaBanUser(id, smodel.UserId)) //user esta banido da sala
                {
                    var message = string.Format("You are banned from {0}.", smodel.Nome);
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.NotFound, err);
                }
                else
                {
                    int return_id = sala.EntraSala(smodel);

                    if(return_id == 0)
                    {
                        var message = string.Format("Wrong Credentials.");
                        HttpError err = new HttpError(message);
                        return Request.CreateResponse(HttpStatusCode.NotFound, err);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, return_id);
                    }
                }
            }

        }

        [Route("Sair")]
        //DELETE: sair de uma sala
        public void DeleteSair(int SalaId)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.SaiSala(userId, SalaId);
        }

        [Route("Utilizadores/Banir")]
        //POST: banir um user de uma sala
        public void PostBanir(SalaIdUsernameModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                SalaAccess sala = new SalaAccess();
                string userId = RequestContext.Principal.Identity.GetUserId();  //id de quem realizou o pedido
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                string idUser = userManager.FindByName(model.Username).Id;    //id do user a banir
                sala.BanirUser(model.SalaId, userId, idUser);
            }
        }

        [Route("Utilizadores/Remover")]
        //POST: remover um user da sala
        public void PostRemoverUserSala(SalaIdUsernameModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                SalaAccess sala = new SalaAccess();
                string userId = RequestContext.Principal.Identity.GetUserId();  //id de quem realizou o pedido
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                string idUser = userManager.FindByName(model.Username).Id;    //id do user a remover
                sala.RemoverUser(model.SalaId, userId, idUser);
            }
        }

        [Route("Utilizadores/Readmitir")]
        //DELETE: desbanir um user
        public void DeleteBanUser(SalaIdUsernameModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                SalaAccess sala = new SalaAccess();
                string userId = RequestContext.Principal.Identity.GetUserId();  //id de quem realizou o pedido
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                string idUser = userManager.FindByName(model.Username).Id;    //id do user a desbanir
                sala.DesbanirUser(model.SalaId, userId, idUser);
            }
        }


        [Route("Utilizadores/Lista")]
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

        [Route("Localizacao/Alterar")]
        //POST: alterar coordenadas de localizacao de uma sala
        public void PostAlterarCoordenadasSala(string SalaId, CoordenadasModel coordenadas)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.AlteraCoordenadasSala(SalaId, coordenadas.Xcoord, coordenadas.Ycoord, userId);
        }

        [Route("Procurar/All")]
        //GET: Listar as Salas
        public List<string> Get()
        {
            //TODO: alterar return para List<Sala___View___Model> -> adicionar mais info às salas

            SalaAccess sala = new SalaAccess();

            return sala.Procurar();
        }

        [Route("Procurar")]
        //GET: Listar as Salas
        public List<string> Get(string Nome)
        {
            SalaAccess sala = new SalaAccess();

            return sala.Procurar(Nome);
        }

        [Route("Procurar/Localizacao")]
        //GET: Listar as N salas mais proximas
        public List <SalaViewModel> Get(float Xcoord, float Ycoord, int NumeroSalas)
        {
            SalaAccess sala = new SalaAccess();

            return sala.Procurar(Xcoord, Ycoord, NumeroSalas);
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
        public HttpResponseMessage PostMusica(int SalaId, MusicaModel musica)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            if (sala.VerficaParticipante(SalaId, userId))
            {
                sala.AdicionaMusicaSala(SalaId, musica, userId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                var message = string.Format("User is not a member of the specified queue");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.Unauthorized, err);
            }
            
        }

        [Route("Musicas/Remover")]
        //DELETE: apagar uma musica
        public void DeleteMusica(int SalaId, string URI, int posicao)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.RemoveMusicaSala(SalaId, URI, posicao, userId);
        }

        [Route("Musicas/AlterarOrdem")]
        //POST: alterar a ordem de uma musica na playlist
        public void PostAlteraPosicao(ModelAlterarPosicaoMusicaSala model)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.AlteraPosicaoMusicaSala(model.SalaId, model.URI, model.PosAtual, model.PosFinal, userId);
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
