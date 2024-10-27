using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestClass]
    public class TarjetaUsoFrecuenteTest
    {
        [TestMethod]
        public void TestDescuentoUsoFrecuente()
        {
            TarjetaComun tarjeta = new TarjetaComun(5000);
            Colectivo colectivo = new ColectivoNormal("Linea 100");

            Boleto boleto1 = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boleto1, "No se generó el boleto");
            Assert.AreEqual(1200, boleto1.GetTotalPagar(), "El boleto no tiene la tarifa normal");

            for (int i = 0; i < 29; i++)
            {
                tarjeta.RegistrarViaje();
            }

            Boleto boleto30 = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boleto30, "No se generó el boleto");
            Assert.AreEqual(960, boleto30.GetTotalPagar(), "El boleto no tiene el descuento del 20%");

            for (int i = 0; i < 49; i++)
            {
                tarjeta.RegistrarViaje();
            }

            Boleto boleto80 = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boleto80, "No se generó el boleto");
            Assert.AreEqual(900, boleto80.GetTotalPagar(), "El boleto no tiene el descuento del 25%");
        }

        [TestMethod]
        public void TestReiniciarViajesDelMes()
        {
            TarjetaComun tarjeta = new TarjetaComun(5000);

            for (int i = 0; i < 30; i++)
            {
                tarjeta.RegistrarViaje();
            }

            tarjeta.ReiniciarViajesDelMes();
            tarjeta.CalcularFranquicia();

            Assert.AreEqual(0, tarjeta.ViajesDelMes, "Los viajes del mes no se reiniciaron");
            Assert.AreEqual(1.0f, tarjeta.Descuento_franquicia, "El descuento no se reinició a tarifa normal");
        }
    }
}
