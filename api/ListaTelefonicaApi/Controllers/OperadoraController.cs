using ListaTelefonicaApi.Data;
using ListaTelefonicaApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ListaTelefonicaApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OperadoraController : ApiController
    {
        public IEnumerable<OperadoraModel> GetOperadoras()
        {
            IEnumerable<OperadoraModel> query = null;

            using (var context = new ListaTelefonicaContext())
            {
                query = context.Operadoras.ToList();
            }

            return query;
        }

    }
}
