using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestClass]
    public class MedioBoletoTests
    {
        [TestInitialize]
        public void Setup()
        {
            Tarjeta.SetTiempo(new Tiempo());
        }

        [TestMethod]
        public void TestNoViajarAntesDe5Minutos()
        {
            var tarjeta = new MedioBoleto(2000);
            var colectivo = new ColectivoNormal ("10");
            tarjeta.CantUsosHoy = 3;
            tarjeta.CalcularFranquicia();

            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(900);
            Tarjeta.SetTiempo(tiempoFalso);

            var boleto1 = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boleto1);

            tiempoFalso.AgregarMinutos(3);
            var boleto2 = colectivo.pagarCon(tarjeta);

            Assert.IsNull(boleto2, "No debería ser posible viajar antes de 5 minutos desde el último viaje.");
        }

        [TestMethod]
        public void TestNoMasDeCuatroViajesPorDia()
        {
            var tarjeta = new MedioBoleto(5000);
            var colectivo = new ColectivoNormal ("Linea 1");
            Boleto[] boletos = new Boleto[5];

            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(900);
            Tarjeta.SetTiempo(tiempoFalso);

            for (int i = 0; i < 4; i++)
            {
                boletos[i] = colectivo.pagarCon(tarjeta);
                if (boletos[i] != null)
                {
                    tiempoFalso.AgregarMinutos(5);
                    Tarjeta.SetTiempo(tiempoFalso);
                }
            }

            tiempoFalso.AgregarMinutos(5);
            Tarjeta.SetTiempo(tiempoFalso);
            tarjeta.CalcularFranquicia();
            boletos[4] = colectivo.pagarCon(tarjeta);

            for (int i = 0; i < 4; i++)
            {
                Assert.IsNotNull(boletos[i], $"Boleto {i + 1} no debería ser nulo.");
                Assert.AreEqual(Boleto.tarifa_pasaje * 0.5f, boletos[i].GetTotalPagar(), $"El boleto {i + 1} debería tener un descuento del 50%.");
            }

            Assert.IsNotNull(boletos[4], "El quinto boleto no debería ser nulo.");
            Assert.AreEqual(Boleto.tarifa_pasaje, boletos[4].GetTotalPagar(), "El quinto boleto debería pagar el precio completo sin descuento.");
        }
    }
}
