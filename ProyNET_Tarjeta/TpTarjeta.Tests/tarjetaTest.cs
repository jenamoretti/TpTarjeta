using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Iteraciones;

namespace TestTarjeta
{
    [TestClass]
    public class TarjetaTests
    {

        [TestMethod]
        public void TestCargaTarjeta()
        {
            foreach (int carga in Tarjeta.posibles_cargas)
            {
                Tarjeta tarjeta = new TarjetaComun(0);
                bool resultado = tarjeta.cargarTarjeta(carga);
                Assert.IsTrue(resultado);
                Assert.AreEqual(carga, tarjeta.Saldo);
            }
        }
    }
}
