using Iteraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestClass]
    public class ColectivoInterurbanoTests
    {
        [TestMethod]
        public void TestTarifaInterurbana()
        {
            var tarjeta = new MedioBoleto(5000);
            var colectivoInterurbano = new ColectivoInterurbano("Rosario-Galvez");

            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(900);
            Tarjeta.SetTiempo(tiempoFalso);

            Boleto boleto = colectivoInterurbano.pagarCon(tarjeta);
            Assert.IsNotNull(boleto, "El boleto no debería ser nulo para una línea interurbana dentro del horario permitido");
            Assert.AreEqual((int)(colectivoInterurbano.ObtenerTarifa() * tarjeta.Descuento_franquicia), boleto.GetTotalPagar(), "La tarifa no se aplicó correctamente para una línea interurbana");
        }
    }
}
