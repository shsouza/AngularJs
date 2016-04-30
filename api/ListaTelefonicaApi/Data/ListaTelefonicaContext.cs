using ListaTelefonicaApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListaTelefonicaApi.Data
{
    public class ListaTelefonicaContext : DbContext
    {
        public ListaTelefonicaContext():base("ListaTelefonica")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<OperadoraModel> Operadoras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}