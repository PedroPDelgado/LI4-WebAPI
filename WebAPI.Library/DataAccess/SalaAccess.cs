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
        public int EntraSala(SalaUserNomePasswordModel model)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.LoadData<int, dynamic>("dbo.spEntraSala", model, "WebAPIData").FirstOrDefault();
        }

        public int CriaSala(SalaUserNomePasswordModel model)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.LoadData<int, dynamic>("dbo.spCriaSala", model, "WebAPIData").FirstOrDefault();
        }

        public List<MusicaModel> GetMusicasSala(int SalaId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = SalaId };

            return sql.LoadData<MusicaModel, dynamic>("dbo.spMusicasSala", parameters, "WebAPIData");
        }

        public void AdicionaMusicaSala(int salaId, string uri, string nome,int duracao, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            SalaMusicaModel model = new SalaMusicaModel();
            model.SalaId = salaId;
            model.MusicaURI = uri;
            model.Nome = nome;
            model.Duracao = duracao;
            model.UserId = userId;

            sql.SaveData<SalaMusicaModel, dynamic > ("dbo.spAdicionaMusicaSala", model, "WebAPIData");
        }

        public void RemoveMusicaSala(int salaId, string URI, string userId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var parameters = new { SalaId = salaId, MusicaURI = URI, UserId = userId };

            sql.DeleteData<string,dynamic>("dbo.spRemoverMusicaSalaURI", parameters, "WebAPIData");
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
    }
}
