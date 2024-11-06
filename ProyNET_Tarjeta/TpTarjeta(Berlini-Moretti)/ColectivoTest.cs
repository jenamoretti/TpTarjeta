using NUnit.Framework;
using Iteraciones;

namespace TpTarjeta.Tests
{
    [TestFixture]
    public class ColectivoTests
    {
        [Test]
        public void TestPagarConSaldoNegativo()
        {
            TarjetaComun tarjeta = new TarjetaComun(-120);
            Colectivo colectivo = new ColectivoNormal("Linea 1");

            Boleto? boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNull(boleto, "El boleto debería ser nulo si el saldo negativo excede los -480");
        }

        [Test]
        public void TestPagarConSaldoPositivo()
        {
            Tarjeta tarjeta = new TarjetaComun(5000);
            Colectivo colectivo = new ColectivoNormal("Linea 2");

            Boleto? boleto = colectivo.pagarCon(tarjeta);

            Assert.IsNotNull(boleto, "El boleto no debería ser nulo");
            Assert.IsNull(boleto.Descripcion, "No debería haber descripción de saldo negativo");
            Assert.AreEqual(tarjeta.Saldo, boleto.SaldoRestante);
        }
    }
}
