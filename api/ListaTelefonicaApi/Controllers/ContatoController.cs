using ListaTelefonicaApi.Data;
using ListaTelefonicaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ListaTelefonicaApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ContatoController : ApiController
    {
        public ContatoController()
        {
            Console.WriteLine("ContatosController");
        }

        public IEnumerable<ContatoModel> GetContatos()
        {
            IEnumerable<ContatoModel> query = null;

            using (var context = new ListaTelefonicaContext())
            {
                query = context.Contatos.Include("operadora").ToList();
            }

            return query;
        }

        public ContatoModel GetContato(int id)
        {
            ContatoModel query = null;

            using (var context = new ListaTelefonicaContext())
            {
                query = context.Contatos.Include("operadora").SingleOrDefault(c => c.Id == id);
            }

            return query;
        }

        [HttpDelete]
        [EnableCors("*", "*", "*")]
        public IHttpActionResult DeleteContato(int id)
        {
            using (var context = new ListaTelefonicaContext())
            {
                var model = context.Contatos.SingleOrDefault(c => c.Id == id);
                context.Contatos.Remove(model);
                context.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult PostContato([FromBody]ContatoModel model)
        {
            model.IdOperadora = model.Operadora.Id;
            model.Operadora = null;

            using (var context = new ListaTelefonicaContext())
            {
                model = context.Contatos.Add(model);
                context.SaveChanges();
            }

            return Ok(model);
        }

    }
}
