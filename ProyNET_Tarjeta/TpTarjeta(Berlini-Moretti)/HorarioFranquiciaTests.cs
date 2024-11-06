using NUnit.Framework;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestFixture]
    public class HorarioFranquiciasTests
    {
        [Test]
        public void TestFranjaHorariaNoPermitida_MedioBoleto()
        {
            MedioBoleto tarjeta = new MedioBoleto(5000);

            // Establecer una hora específica fuera de la franja permitida
            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(1380); // Establecer a las 23:00 (1380 minutos desde medianoche)
            Tarjeta.SetTiempo(tiempoFalso);

            Colectivo colectivo = new ColectivoNormal("Linea 100");
            Boleto boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNull(boleto, "El boleto no debería generarse fuera de la franja horaria permitida");
        }

        [Test]
        public void TestFranjaHorariaNoPermitida_FranquiciaCompleta()
        {
            BoletoJubilados tarjeta = new BoletoJubilados(5000);

            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(1380);
            Tarjeta.SetTiempo(tiempoFalso);

            Colectivo colectivo = new ColectivoNormal("Linea 100");
            Boleto boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNull(boleto, "El boleto no debería generarse fuera de la franja horaria permitida");
        }
    }
}
