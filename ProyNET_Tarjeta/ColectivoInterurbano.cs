using System;
using Iteraciones;

namespace Iteraciones
{
    public class ColectivoInterurbano : Colectivo
    {
        public ColectivoInterurbano(string linea) : base(linea) { }

        public override float ObtenerTarifa()
        {
            return Boleto.tarifa_interurbana;
        }
    }
}
