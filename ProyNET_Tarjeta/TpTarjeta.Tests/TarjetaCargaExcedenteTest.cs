using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestClass]
    public class TarjetaCargaExcedenteTest
    {
        [TestMethod]
        public void TestCargaConExcedente()
        {
            var tarjeta = new TarjetaComun(35000);

            tarjeta.cargarTarjeta(5000);

            Assert.AreEqual(36000, tarjeta.Saldo, "El saldo no debe superar el máximo permitido.");

            Assert.AreEqual(4000, tarjeta.AcreditaciónPendiente, "El excedente debe quedar pendiente de acreditación.");
        }

        [TestMethod]
        public void TestAcreditarSaldoPendienteDespuésDeViaje()
        {
            TarjetaComun tarjeta = new TarjetaComun(34000);
            tarjeta.cargarTarjeta(4000);
            Colectivo colectivo = new ColectivoNormal("Linea 100");

            Boleto boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNotNull(boleto, "No se generó el boleto");
            Assert.AreEqual(800, tarjeta.AcreditaciónPendiente);
            Assert.AreEqual(Tarjeta.max_carga, tarjeta.Saldo);
        }

    }
}
