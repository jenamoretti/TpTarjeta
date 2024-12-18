﻿using NUnit.Framework;
using Iteraciones;
using TpTarjeta.Tests;

namespace IteracionesTests
{
    [TestFixture]
    public class FranquiciaCompletaTests
    {
        [Test]
        public void TestFranquiciaCompletaSiemprePuedePagar()
        {
            BoletoJubilados tarjeta = new BoletoJubilados(1000);

            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(900);
            Tarjeta.SetTiempo(tiempoFalso);

            int tarifa = 3000;
            bool puedeViajar = tarjeta.EsPosibleViajar(tarifa);
            Assert.IsTrue(puedeViajar, "La tarjeta de FranquiciaCompleta debe poder pagar un boleto dentro de la franja horaria permitida");
        }

        [Test]
        public void TestMedioBoletoPagaLaMitad()
        {
            MedioBoleto tarjeta = new MedioBoleto(5000);
            Colectivo colectivo = new ColectivoNormal("Linea 1");

            TiempoFalso tiempoFalso = new TiempoFalso();
            tiempoFalso.AgregarMinutos(900);
            Tarjeta.SetTiempo(tiempoFalso);

            Boleto? boleto = colectivo.pagarCon(tarjeta);
            Assert.IsNotNull(boleto, "El boleto no debería ser nulo");
            Assert.AreEqual(Boleto.tarifa_pasaje * 0.5f, boleto.GetTotalPagar(), "El monto del boleto pagado con MedioBoleto debe ser siempre la mitad del normal dentro de la franja horaria permitida");
        }
    }
}
