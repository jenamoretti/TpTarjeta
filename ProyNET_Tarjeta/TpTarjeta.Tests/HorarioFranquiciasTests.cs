using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestClass]
    public class HorarioFranquiciasTests
    {
        [TestMethod]
        public void TestFranjaHorariaNoPermitida_MedioBoleto()
        {
            MedioBoleto tarjeta = new MedioBoleto(5000);

            // Establecer una hora específica fuera de la franja permitida
            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(1380); // Establecer a las 23:00 (1380 minutos desde medianoche)
            Tarjeta.SetTiempo(tiempoFalso);

            Colectivo colectivo = new ColectivoNormal ("Linea 100");
            Boleto boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNull(boleto, "El boleto no debería generarse fuera de la franja horaria permitida");
        }

        [TestMethod]
        public void TestFranjaHorariaNoPermitida_FranquiciaCompleta()
        {
            FranquiciaCompleta tarjeta = new FranquiciaCompleta(5000);

            // Establecer una hora específica fuera de la franja permitida
            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(1380); // Establecer a las 23:00 (1380 minutos desde medianoche)
            Tarjeta.SetTiempo(tiempoFalso);

            Colectivo colectivo = new ColectivoNormal ("Linea 100");
            Boleto boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNull(boleto, "El boleto no debería generarse fuera de la franja horaria permitida");
        }
    }
}
