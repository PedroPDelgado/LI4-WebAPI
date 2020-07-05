using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Library.Internal.DataAccess;
using WebAPI.Library.Models;

namespace WebAPI.Library.DataAccess
{
    public class SalaAccess
        
    {
        public int GetSalaId(string nome)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = 0, Nome = nome };

            return sql.LoadData<int, dynamic>("dbo.spSalaId", parameter, "WebAPIData").FirstOrDefault();
        }

        public int EntraSala(SalaUserNomePasswordModel model)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.LoadData<int, dynamic>("dbo.spEntraSala", model, "WebAPIData").FirstOrDefault();
        }

        public int CriaSala(SalaCriarModel model)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.LoadData<int, dynamic>("dbo.spCriaSala", model, "WebAPIData").FirstOrDefault();
        }

        public List<MusicaModel> GetMusicasSala(int SalaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = SalaId };

            List<MusicaModel> musicas = sql.LoadData<MusicaModel, dynamic>("dbo.spMusicasSala", parameters, "WebAPIData");

            foreach(MusicaModel musica in musicas)
            {
                var p = new { Uri = musica.URI };

                List<string> list = sql.LoadData<string, dynamic>("dbo.spArtistasMusica", p, "WebAPIData");
                
                musica.Artistas = list;
            }

            return musicas;
        }

        public void AlteraCoordenadasSala(string salaId, double xcoord, double ycoord, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, Xcoord = xcoord, Ycoord = ycoord, UserId = userId};

            sql.AlterData<string, dynamic>("dbo.spAlteraCoordenadasSala", parameters, "WebAPIData");
        }

        public void AdicionaMusicaSala(int salaId, MusicaModel musica, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { URI = musica.URI };

            string uri = sql.LoadData<string, dynamic>("dbo.spExisteMusica", parameters, "WebAPIData").FirstOrDefault();

            if (uri == null)
            {
                var musicaParams = new { MusicaURI = musica.URI, Nome = musica.Nome, Duracao = musica.Duracao_ms, Album = musica.Album, Url_imagem = musica.Url_imagem };

                sql.SaveData<MusicaModel, dynamic>("dbo.spAdicionaMusica", musicaParams, "WebAPIData");

                foreach(string artista in musica.Artistas)
                {
                    var artistaParam = new { MusicaURI = musica.URI, Artista = artista };

                    sql.SaveData<MusicaModel, dynamic>("dbo.spAdicionaArtistaMusica", artistaParam, "WebAPIData");
                }
            }

            var paramSalaId = new { SalaId = salaId };

            var paramsSalaMusicaUser = new { SalaId = salaId, MusicaURI = musica.URI, UserId = userId };

            sql.SaveData<string, dynamic>("dbo.spAdicionaMusicaSala", paramsSalaMusicaUser, "WebAPIData");

        }

        public void AlteraNome(int salaId, string nome, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, Nome = nome, UserId = userId };

            sql.AlterData<string, dynamic>("dbo.spAlteraNomeSala", parameters, "WebAPIData");
        }

        public void AlteraPassword(int salaId, string password, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, Password = password, UserId = userId };

            sql.AlterData<string, dynamic>("dbo.spAlteraPasswordSala", parameters, "WebAPIData");
        }

        public List<string> Procurar(string nome)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Nome = nome };

            return sql.LoadData<string, dynamic>("dbo.spProcurarSalaNome", parameters, "WebAPIData");
        }

        public void RemoveMusicaSala(int salaId, string URI, int posicao ,string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, MusicaURI = URI, Posicao = posicao, UserId = userId };

            sql.DeleteData<string,dynamic>("dbo.spRemoverMusicaSalaURI", parameters, "WebAPIData");
        }

        public void BanirUser(int salaId, string userId, string idUser)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, UserId = userId, IdABanir = idUser };

            sql.SaveData<string, dynamic>("dbo.spBanirUserSala", parameters, "WebAPIData");
        }

        public void SaiSala(string userId, int salaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            UserSalaModel model = new UserSalaModel();
            model.UserId = userId;
            model.SalaId = salaId;

            sql.DeleteData<Tuple<string, int>, dynamic>("dbo.spSairSala", model, "WebAPIData");

        }

        public void AbreSala(int salaId, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { UserId = userId, SalaId = salaId };

            sql.AlterData<Tuple<string, int>, dynamic>("dbo.spAbreSala", parameters, "WebAPIData");
        }

        public List<SalaViewModel> Procurar(float xcoord, float ycoord, int numeroSalas)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { Xcoord = xcoord, Ycoord = ycoord, NumSalas = numeroSalas };

            List<SalaViewModel> models = sql.LoadData<SalaViewModel, dynamic>("dbo.spSalasMaisProximas", parameters, "WebAPIData");

            return models;
        }

        public void RemoverUser(int salaId, string userId, string idARemover)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, UserId = userId, IdARemover = idARemover };

            sql.DeleteData<string, dynamic>("dbo.spRemoveUserSala", parameters, "WebAPIData");
        }

        public int GetIdSala(string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { IdUser = userId };  

            int id = sql.LoadData<int, dynamic>("dbo.spGetIdSalaUser", parameter, "WebAPIData").FirstOrDefault();

            return id;
        }

        public bool IsOwner(int idSala, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = idSala, UserId = userId };

            int res = sql.LoadData<int, dynamic>("dbo.spIsOwner", parameters, "WebAPIData").FirstOrDefault();

            return (res == 1);
        }

        public bool VerificaBanUser(int salaId, string userId) //retorna true se o user estiver banido da Sala
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, UserId = userId };

            int existe = sql.LoadData<int, dynamic>("dbo.spVerificaBanUserSala", parameters, "WebAPIData").FirstOrDefault();

            return (existe == 1);
        }

        public void DesbanirUser(int salaId, string userId, string idUser)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, UserId = userId, IdADesbanir = idUser };

            sql.DeleteData<int, dynamic>("dbo.spDesbaneUser", parameters, "WebAPIData");
        }

        public string GetNomeSala(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = id };

            string nome = sql.LoadData<string, dynamic>("dbo.spGetNomeSala", parameter, "WebAPIData").FirstOrDefault();

            return nome;
        }

        public bool VerficaParticipante(int salaId, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, UserId = userId };

            int existe = sql.LoadData<int, dynamic>("dbo.spVerificaParticipante", parameters, "WebAPIData").FirstOrDefault();

            return (existe == 1);
        }

        public void AlteraPosicaoMusicaSala(int salaId, string uri, int posAtual, int posFinal, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { UserId = userId, SalaId = salaId, MusicaURI = uri, PosicaoAtual = posAtual, PosicaoFinal = posFinal };

            sql.AlterData<string, dynamic>("dbo.spAlteraPosicaoMusicaSala", parameters, "WebAPIData");
        }

        public List<string> Procurar()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { };

            return sql.LoadData<string, dynamic>("dbo.spListaSalas", parameters, "WebAPIData");
        }

        public void ApagaSala(int salaId, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { UserId = userId, SalaId = salaId };

            sql.DeleteData<Tuple<string, int>, dynamic>("dbo.spApagaSala", parameters, "WebAPIData");
        }

        public List<string> GetUsersSala(int idSala)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = idSala };

            return sql.LoadData<string,dynamic>("dbo.spUsersSala", parameter, "WebAPIData");
        }

        public List<string> GetFiltros(int salaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = salaId };

            return sql.LoadData<string, dynamic>("dbo.spFiltrosSala", parameter, "WebAPIData");
        }

        public void AlteraFiltros(int salaId, string userId, List<string> filtros)
        {
            SqlDataAccess sql = new SqlDataAccess();

            RemoveFiltros(salaId, userId);

            foreach(string filtro in filtros)
            {
                var parameter = new { SalaId = salaId, UserId = userId ,Filtro = filtro };

                sql.SaveData<int, dynamic>("dbo.spAdicionaFiltroSala", parameter, "WebAPIData");
            }
        }

        private void RemoveFiltros(int salaId, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = salaId, UserId = userId };

            sql.DeleteData<int, dynamic>("dbo.spRemoveFiltrosSala", parameter, "WebAPIData");
        }


        public List<string> GetBansSala(int salaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = salaId };

            return sql.LoadData<string, dynamic>("dbo.spBansSala", parameter, "WebAPIData");
        }

        public int GetMusicaAtual(int salaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameter = new { SalaId = salaId };

            return sql.LoadData<int, dynamic>("dbo.spMusicaAtualSala", parameter, "WebAPIData").FirstOrDefault();
        }

        public void AtualizaMusicaAtual(int salaId, int posicao)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, Posicao = posicao };

            sql.AlterData<int, dynamic>("dbo.spAlteraMusicaAtualSala", parameters, "WebAPIData");
        }
    }
}
