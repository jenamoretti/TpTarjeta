using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestClass]
    public class BoletoEducativoGratuitoTests
    {
        [TestMethod]
        public void TestNoMasDeDosViajesGratuitosPorDia()
        {
            var tarjeta = new FranquiciaCompleta(1000);
            var colectivo = new ColectivoNormal ("Linea 1");
            Boleto[] boletos = new Boleto[3];

            for (int i = 0; i < 2; i++)
            {
                boletos[i] = colectivo.pagarCon(tarjeta);
                Assert.IsNotNull(boletos[i], $"El viaje {i + 1} debería ser gratuito");
                Console.WriteLine($"Viaje {i + 1}: Saldo = {tarjeta.Saldo}, Usos hoy = {tarjeta.CantUsosHoy}");

                boletos[i].GetType().GetProperty("Fecha").SetValue(boletos[i], DateTime.Now.AddMinutes(-(5 * (i + 1))));
            }

            boletos[2] = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boletos[2], "El tercer viaje no debería ser nulo");
            Assert.AreEqual(Boleto.tarifa_pasaje, boletos[2].GetTotalPagar(), "El tercer viaje debería cobrarse con tarifa completa");
        }

        [TestMethod]
        public void TestViajesPosterioresAlSegundoCobranTarifaCompleta()
        {
            var tarjeta = new FranquiciaCompleta(1000);
            var colectivo = new ColectivoNormal ("Linea 1");
            Boleto[] boletos = new Boleto[3];

            for (int i = 0; i < 2; i++)
            {
                boletos[i] = colectivo.pagarCon(tarjeta);
                Assert.IsNotNull(boletos[i], $"El viaje {i + 1} debería ser gratuito");
                Console.WriteLine($"Viaje {i + 1}: Saldo = {tarjeta.Saldo}, Usos hoy = {tarjeta.CantUsosHoy}");

                boletos[i].GetType().GetProperty("Fecha").SetValue(boletos[i], DateTime.Now.AddMinutes(-(5 * (i + 1))));
            }

            boletos[2] = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boletos[2], "El tercer viaje no debería ser nulo");
            Assert.AreEqual(Boleto.tarifa_pasaje, boletos[2].GetTotalPagar(), "El tercer viaje debería cobrarse con tarifa completa");
        }
    }
}
