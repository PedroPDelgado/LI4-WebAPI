using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Errors;
using WebAPI.Library.DataAccess;
using WebAPI.Library.Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Controlador que permite interagir com Salas.
    /// </summary>

    [Authorize]
    [RoutePrefix("api/Sala")]
    public class SalaController : ApiController
    {

        /// <summary>
        /// Cria uma nova Sala.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Criar")]
        //POST: criar uma sala
        /* Coordenadas e Limites de Musicas/Horas sao opcionais
         */
        public HttpResponseMessage PostCriar(SalaCriacaoModel model)
        {
            ErrorReader errorReader = new ErrorReader();

            if(Math.Abs(model.Xcoord) > 90 || Math.Abs(model.Ycoord) > 180)
            {
                var message = string.Format(errorReader.GetErrorMessage(0));
                HttpError err = new HttpError(message);
                return Request.CreateResponse(errorReader.GetError(0), err);
            }
            else
            {
                if(model.Nome.Equals("") || model.Password.Equals(""))
                {
                    var message = string.Format(errorReader.GetErrorMessage(8));
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(errorReader.GetError(8), err);
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

                    return Request.CreateResponse(HttpStatusCode.OK, sala.CriaSala(smodel));
                }
                
            }
        }

        /// <summary>
        /// Altera o nome da Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="model"></param>
        [Route("Nome/Alterar")]
        //POST: altera nome da sala
        public void PostAlterarNome(SalaIdNomeModel model)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.AlteraNome(model.SalaId, model.Nome, userId);
        }

        /// <summary>
        /// Altera a password da Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="model"></param>
        [Route("Password/Alterar")]
        //POST: altera password da sala
        public void PostAlterarPassword(SalaIdPasswordModel model)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.AlteraPassword(model.SalaId, model.Password, userId);
        }

        /// <summary>
        /// Elimina uma Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="SalaId">Identificador da Sala.</param>
        [Route("Eliminar")]
        //DELETE: apaga uma sala
        public void DeleteApagar(int SalaId)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.ApagaSala(SalaId, userId);
        }

        /// <summary>
        /// Entra numa Sala.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Entrar")]
        //Post: entra numa sala
        public HttpResponseMessage PostEntrar(NomePasswordModel model)
        {
            ErrorReader errorReader = new ErrorReader();

            SalaAccess sala = new SalaAccess();

            SalaUserNomePasswordModel smodel = new SalaUserNomePasswordModel();

            smodel.UserId = RequestContext.Principal.Identity.GetUserId();
            smodel.Nome = model.Nome;
            smodel.Password = model.Password;

            int id = sala.GetSalaId(smodel.Nome);

            if (id == 0)
            {
                var message = string.Format(errorReader.GetErrorMessage(1), smodel.Nome);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(errorReader.GetError(1), err);
            }
            else
            {
                if(sala.VerificaBanUser(id, smodel.UserId)) //user esta banido da sala
                {
                    var message = string.Format(errorReader.GetErrorMessage(2), smodel.Nome);
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(errorReader.GetError(2), err);
                }
                else
                {
                    int return_id = sala.EntraSala(smodel);

                    if(return_id == 0)
                    {
                        var message = string.Format(errorReader.GetErrorMessage(3));
                        HttpError err = new HttpError(message);
                        return Request.CreateResponse(errorReader.GetError(3), err);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, return_id);
                    }
                }
            }

        }
        /// <summary>
        /// Retorna informação sobre o utilizador relativa ao seu Id, Nome e se se trata de um Owner. 
        /// </summary>
        [Route("Info")]
        public HttpResponseMessage GetInfo()
        {
            SalaAccess sala = new SalaAccess();

            ErrorReader errorReader = new ErrorReader();

            string userId = RequestContext.Principal.Identity.GetUserId();

            int idSala = sala.GetIdSala(userId);

            if(idSala == 0)
            {
                var message = string.Format(errorReader.GetErrorMessage(9));
                HttpError err = new HttpError(message);
                return Request.CreateResponse(errorReader.GetError(9), err);
            }
            else
            {
                string nomeSala = sala.GetNomeSala(idSala);
                bool isOnwer = sala.IsOwner(idSala, userId);

                InfoModel model = new InfoModel();
                model.Id = idSala;
                model.Nome = nomeSala;
                model.isOwner = isOnwer;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
        }

        
        /// <summary>
        /// Sai de uma Sala.
        /// </summary>
        /// <param name="SalaId">Identificador da Sala.</param>
        [Route("Sair")]
        //DELETE: sair de uma sala
        public void DeleteSair(int SalaId)
        {
            SalaAccess sala = new SalaAccess();
            string userId = RequestContext.Principal.Identity.GetUserId();
            sala.SaiSala(userId, SalaId);
        }
        /// <summary>
        /// Bane um utilizador da Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="model"></param>
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
        /// <summary>
        /// Remove um utilizador de uma Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="model"></param>
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
        /// <summary>
        /// Readmite um utilizador removendo-o da lista de utilizadores banidos da Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="model"></param>
        [Route("Utilizadores/Readmitir")]
        //POST: desbanir um user
        public void PostBanUser(SalaIdUsernameModel model)
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

        /// <summary>
        /// Retorna a lista de usernames dos utilizadores da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Retorna a lista de usernames dos utilizadores banidos da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        [Route("Utilizadores/Banidos")]
        public List<String> GetBans(int SalaId)
        {
            using (var context = new ApplicationDbContext())
            {

                List<string> res = new List<string>();

                SalaAccess sala = new SalaAccess();

                List<string> userIds = sala.GetBansSala(SalaId);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                foreach (string id in userIds)
                {
                    res.Add(userManager.FindById(id).UserName);
                }

                return res;
            }
        }
    

        /// <summary>
        /// Altera as coordenadas de localização da Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        /// <param name="coordenadas"></param>
        [Route("Localizacao/Alterar")]
        //POST: alterar coordenadas de localizacao de uma sala
        public void PostAlterarCoordenadasSala(string SalaId, CoordenadasModel coordenadas)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.AlteraCoordenadasSala(SalaId, coordenadas.Xcoord, coordenadas.Ycoord, userId);
        }

        /// <summary>
        /// Retorna uma lista com os nomes de todas as Salas.
        /// </summary>
        /// <returns></returns>
        [Route("Procurar/All")]
        //GET: Listar as Salas
        public List<string> Get()
        {
            //TODO: alterar return para List<Sala___View___Model> -> adicionar mais info às salas

            SalaAccess sala = new SalaAccess();

            return sala.Procurar();
        }

        /// <summary>
        /// Retorna uma lista com os nomes das Salas cujo nome contenha a string procurada (case insensitive).
        /// </summary>
        /// <param name="Nome">Nome da Sala a procurar.</param>
        /// <returns></returns>
        [Route("Procurar")]
        //GET: Listar as Salas
        public List<string> Get(string Nome)
        {
            SalaAccess sala = new SalaAccess();

            return sala.Procurar(Nome);
        }

        /// <summary>
        /// Retorna uma lista com os nomes das N Salas mais próximas do utilizador com base nas suas coordenadas.
        /// </summary>
        /// <param name="Xcoord">Latitude do utilizador.</param>
        /// <param name="Ycoord">Longitude do utilizador.</param>
        /// <param name="NumeroSalas">Número máximo de salas a retornar.</param>
        /// <returns></returns>
        [Route("Procurar/Localizacao")]
        //GET: Listar as N salas mais proximas
        public List <SalaViewModel> Get(float Xcoord, float Ycoord, int NumeroSalas)
        {
            SalaAccess sala = new SalaAccess();

            return sala.Procurar(Xcoord, Ycoord, NumeroSalas);
        }

        /// <summary>
        /// Retorna uma lista com as músicas de uma Sala por ordem da sua posição. Ação restrita a participantes da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        /// <returns></returns>
        [Route("Musicas/Lista")]
        //GET: listar musicas de uma sala
        public List<MusicaModel> GetMusicas(int SalaId)
        {
            SalaAccess sala = new SalaAccess();

            return sala.GetMusicasSala(SalaId);

        }

        /// <summary>
        /// Adiciona uma música à Sala. Ação restrita a participantes da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        /// <param name="musica"></param>
        /// <returns></returns>
        [Route("Musicas/Adicionar")]
        //POST: adiciona Musica a Sala
        public HttpResponseMessage PostMusica(int SalaId, MusicaModel musica)
        {
            ErrorReader errorReader = new ErrorReader();

            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            if (sala.VerficaParticipante(SalaId, userId))
            {
                sala.AdicionaMusicaSala(SalaId, musica, userId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                var message = string.Format(errorReader.GetErrorMessage(4));
                HttpError err = new HttpError(message);
                return Request.CreateResponse(errorReader.GetError(4), err);
            }
            
        }

        /// <summary>
        /// Remove uma música da Sala. Ação restrita ao owner da Sala e ao participante que adicionou a música.
        /// </summary>
        /// <param name="SalaId">Identificador da Sala.</param>
        /// <param name="URI">Identificador da música.</param>
        /// <param name="posicao">Posição da música na queue.</param>
        [Route("Musicas/Remover")]
        //DELETE: apagar uma musica
        public void DeleteMusica(int SalaId, string URI, int posicao)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.RemoveMusicaSala(SalaId, URI, posicao, userId);
        }

        /// <summary>
        /// Altera a ordem de uma música na Sala. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="model"></param>
        [Route("Musicas/AlterarOrdem")]
        //POST: alterar a ordem de uma musica na playlist
        public void PostAlteraPosicao(ModelAlterarPosicaoMusicaSala model)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            sala.AlteraPosicaoMusicaSala(model.SalaId, model.URI, model.PosAtual, model.PosFinal, userId);
        }

        /// <summary>
        /// Retorna a música atual a tocar da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        [Route("Musicas/MusicaAtual")]
        public int GetMusicaAtual(int SalaId)
        {
            SalaAccess sala = new SalaAccess();

            return sala.GetMusicaAtual(SalaId);
        }

        /// <summary>
        /// Altera a música atual a tocar da Sala.
        /// </summary>
        /// <param name="SalaId"></param>
        /// <param name="Posicao"></param>
        [Route("Musicas/MusicaAtual")]
        public void PostMusicaAtual(int SalaId, int Posicao)
        {
            SalaAccess sala = new SalaAccess();

            string userId = RequestContext.Principal.Identity.GetUserId();

            if(sala.IsOwner(SalaId, userId))
            {
                sala.AtualizaMusicaAtual(SalaId, Posicao);
            }
        }

        /// <summary>
        /// Retorna a lista de filtros da Sala. Ação restrita aos participantes da Sala.
        /// </summary>
        /// <param name="SalaId">Identificador da Sala.</param>
        /// <returns></returns>
        [Route("Filtros/Lista")]
        //GET: devolve os filtros de uma sala
        public List<string> GetFiltros(int SalaId)
        {
            SalaAccess sala = new SalaAccess();

            return sala.GetFiltros(SalaId);
        }

        /// <summary>
        /// Substitui os filtros da Sala pelos filtros especificados. Ação restrita ao owner da Sala.
        /// </summary>
        /// <param name="SalaId">Identificador da Sala.</param>
        /// <param name="filtros">Lista de novos filtros.</param>
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
