using System;
using Iteraciones;

namespace Iteraciones
{
    public class ColectivoNormal : Colectivo
    {
        public ColectivoNormal(string linea) : base(linea) { }

        public override float ObtenerTarifa()
        {
            return Boleto.tarifa_pasaje;
        }
    }
}

