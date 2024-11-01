using System;
using Iteraciones;

namespace Iteraciones
{
    public class Boleto
    {
        public static float tarifa_pasaje = 1200.0f;
        public int SaldoRestante { get; set; }
        private Tarjeta tarjeta;
        public string TipoTarjeta { get; private set; }
        public string LineaViajada { get; private set; }
        public int TotalAPagar { get; private set; }
        public DateTime Fecha { get; private set; }
        public string? Descripcion { get; set; }

        public Boleto(Tarjeta tarjeta, Colectivo colectivo)
        {
            this.tarjeta = tarjeta ?? throw new ArgumentNullException(nameof(tarjeta));
            if (colectivo == null) throw new ArgumentNullException(nameof(colectivo));

            Fecha = Tarjeta.GetTiempoActual();
            TipoTarjeta = tarjeta.GetType().Name;
            TotalAPagar = CalcularTotalAPagar(tarjeta);
            LineaViajada = colectivo.Linea;
        }

        private int CalcularTotalAPagar(Tarjeta tarjeta)
        {
            return (int)(tarifa_pasaje * tarjeta.Descuento_franquicia);
        }

        public DateTime GetFecha() => Fecha;
        public string GetTipoTarjeta() => TipoTarjeta;
        public string GetLineaColectivo() => LineaViajada;
        public int GetTotalPagar() => TotalAPagar;
        public int GetSaldo() => tarjeta.Saldo;
        public int GetIdTarjeta() => tarjeta.Id;
    }
}
