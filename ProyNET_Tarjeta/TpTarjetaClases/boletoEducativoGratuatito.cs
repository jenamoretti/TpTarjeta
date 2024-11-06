using System;
using System.Collections.Generic;

namespace Iteraciones

{
    public class BoletoEstudiantil : FranquiciaCompleta
    {
        public BoletoEstudiantil(int saldo) : base(saldo)
        {
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