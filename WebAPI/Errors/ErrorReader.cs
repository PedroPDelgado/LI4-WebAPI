using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAPI.Errors
{
    public class ErrorReader
    {
        /// <summary>
        /// Classe que trata dos erros da API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetErrorMessage(int id)
        {
            string[] linha = File.ReadLines(HttpContext.Current.Server.MapPath("~") + "Errors/ErrorMessages.txt").Skip(id).Take(1).First().Split('#');

            return linha[0];

        }

        public HttpStatusCode GetError(int id)
        {
            string[] linha = File.ReadLines(HttpContext.Current.Server.MapPath("~") + "Errors/ErrorMessages.txt").Skip(id).Take(1).First().Split('#');

            return GetHttpStatusCode(Int32.Parse(linha[1]));
        }

        private HttpStatusCode GetHttpStatusCode(int id)
        {
            switch (id)
            {
                case 400:
                    return HttpStatusCode.BadRequest;
                case 200:
                    return HttpStatusCode.OK;
                case 404:
                    return HttpStatusCode.NotFound;
                case 401:
                    return HttpStatusCode.Unauthorized;
                default:
                    throw new Exception("Invalid error code");
            }
        }


    }
}