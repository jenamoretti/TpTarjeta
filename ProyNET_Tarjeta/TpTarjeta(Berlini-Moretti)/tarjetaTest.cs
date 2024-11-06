using NUnit.Framework;
using System.Collections.Generic;
using Iteraciones;

namespace TestTarjeta
{
    [TestFixture]
    public class TarjetaTests
    {
        [Test]
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
