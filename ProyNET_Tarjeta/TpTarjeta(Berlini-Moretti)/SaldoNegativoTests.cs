using NUnit.Framework;
using Iteraciones;

namespace IteracionesTests
{
    [TestFixture]
    public class SaldoYDescuentoTests
    {
        [Test]
        public void TestNoPermitePagoSinSaldo()
        {
            Tarjeta tarjeta = new TarjetaComun(200);
            int tarifa = 3000;

            bool resultado = tarjeta.EsPosibleViajar(tarifa);

            Assert.IsFalse(resultado, "No debería ser posible pagar sin saldo suficiente");
            Assert.AreEqual(200, tarjeta.Saldo, "El saldo debería permanecer igual al no permitirse el pago");
        }

        [Test]
        public void TestRecargaDescontandoSaldoAdeudado()
        {
            Tarjeta tarjeta = new TarjetaComun(-480);
            int recarga = 5000;

            tarjeta.cargarTarjeta(recarga);

            Assert.AreEqual(4520, tarjeta.Saldo, "El saldo debería ser 4520 después de la recarga");
        }
    }
}
