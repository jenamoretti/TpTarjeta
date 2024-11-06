using System;
using System.Collections.Generic;

namespace Iteraciones
{
    public class FranquiciaCompleta : Tarjeta
    {
        // Atributos
        private float desc;

        public override float Descuento_franquicia
        {
            get { return desc; }
            set { desc = value; }
        }

        // Constructor
        public FranquiciaCompleta(int saldo) : base(saldo)
        {
            desc = 0.0f;
        }

        // Métodos
        public override bool EsPosibleViajar(int tarifa)
        {
            if (!EsHorarioValido())
                return false;

            return true;
        }

        public override void CalcularFranquicia()
        {
            if (CantUsosHoy < 2)
                Descuento_franquicia = 0.0f;
            else
                Descuento_franquicia = 1.0f;
        }
    }
}