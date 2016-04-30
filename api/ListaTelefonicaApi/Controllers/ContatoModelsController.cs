using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ListaTelefonicaApi.Data;
using ListaTelefonicaApi.Models;

namespace ListaTelefonicaApi.Controllers
{
    public class ContatoModelsController : ApiController
    {
        private ListaTelefonicaContext db = new ListaTelefonicaContext();

        // GET: api/ContatoModels
        public IQueryable<ContatoModel> GetContatos()
        {
            return db.Contatos;
        }

        // GET: api/ContatoModels/5
        [ResponseType(typeof(ContatoModel))]
        public IHttpActionResult GetContatoModel(int id)
        {
            ContatoModel contatoModel = db.Contatos.Find(id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return Ok(contatoModel);
        }

        // PUT: api/ContatoModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContatoModel(int id, ContatoModel contatoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contatoModel.Id)
            {
                return BadRequest();
            }

            db.Entry(contatoModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContatoModels
        [ResponseType(typeof(ContatoModel))]
        public IHttpActionResult PostContatoModel(ContatoModel contatoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contatos.Add(contatoModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contatoModel.Id }, contatoModel);
        }

        // DELETE: api/ContatoModels/5
        [ResponseType(typeof(ContatoModel))]
        public IHttpActionResult DeleteContatoModel(int id)
        {
            ContatoModel contatoModel = db.Contatos.Find(id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            db.Contatos.Remove(contatoModel);
            db.SaveChanges();

            return Ok(contatoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContatoModelExists(int id)
        {
            return db.Contatos.Count(e => e.Id == id) > 0;
        }
    }
}