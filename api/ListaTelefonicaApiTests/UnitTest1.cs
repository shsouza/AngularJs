using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListaTelefonicaApi.Data;
using ListaTelefonicaApi.Models;
using System.Linq;

namespace ContatosApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MigrateOperadoras()
        {
            using (var context = new ListaTelefonicaContext())
            {
                if (context.Operadoras.Count() == 0)
                {
                    context.Operadoras.Add(new OperadoraModel() { Nome = "Vivo" });
                    context.Operadoras.Add(new OperadoraModel() { Nome = "Claro" });
                    context.Operadoras.Add(new OperadoraModel() { Nome = "Tim" });
                    context.Operadoras.Add(new OperadoraModel() { Nome = "Oi" });
                    context.Operadoras.Add(new OperadoraModel() { Nome = "Embratel" });
                    context.SaveChanges();
                }
            }
        }
    }
}
