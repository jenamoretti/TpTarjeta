using System;
using NUnit.Framework;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestFixture]
    public class BoletoTests
    {
        [Test]
        public void TestBoletoFranquiciaCompleta()
        {
            var tarjeta = new FranquiciaCompleta(2000);
            var colectivo = new ColectivoNormal("10");
            tarjeta.CantUsosHoy = 1;
            tarjeta.CalcularFranquicia();

            var boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNotNull(boleto);
            Assert.AreEqual(0, boleto.TotalAPagar);
            Assert.AreEqual(2000, boleto.SaldoRestante);
            Assert.AreEqual("FranquiciaCompleta", boleto.GetTipoTarjeta());
            Assert.AreEqual("10", boleto.GetLineaColectivo());
        }

        [Test]
        public void TestBoletoMedioBoleto()
        {
            var tarjeta = new MedioBoleto(2000);
            var colectivo = new ColectivoNormal("20");
            tarjeta.CantUsosHoy = 3;
            tarjeta.CalcularFranquicia();

            var boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNotNull(boleto);
            Assert.AreEqual(600, boleto.TotalAPagar);
            Assert.AreEqual(1400, boleto.SaldoRestante);
            Assert.AreEqual("MedioBoleto", boleto.GetTipoTarjeta());
            Assert.AreEqual("20", boleto.GetLineaColectivo());
        }

        [Test]
        public void TestBoletoTarjetaComun()
        {
            var tarjeta = new TarjetaComun(2000);
            var colectivo = new ColectivoNormal("30");
            tarjeta.CalcularFranquicia();

            var boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNotNull(boleto);
            Assert.AreEqual(1200, boleto.TotalAPagar);
            Assert.AreEqual(800, boleto.SaldoRestante);
            Assert.AreEqual("TarjetaComun", boleto.GetTipoTarjeta());
            Assert.AreEqual("30", boleto.GetLineaColectivo());
        }

        [Test]
        public void TestBoletoDescripcionDeudaPaga()
        {
            var tarjeta = new TarjetaComun(-120);
            tarjeta.cargarTarjeta(2000);
            var colectivo = new ColectivoNormal("40");
            tarjeta.CalcularFranquicia();

            var boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNotNull(boleto);
            Assert.AreEqual("El boleto abonó 120 pesos de saldo negativo en la última carga", boleto.Descripcion);
        }
    }
}
