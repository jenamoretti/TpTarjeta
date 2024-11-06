using System;
using System.Collections.Generic;
using Iteraciones;
using System.Linq;

namespace Iteraciones
{
    public class TarjetaComun : Tarjeta
    {
        // Atributos
        private float desc;

        public override float Descuento_franquicia
        {
            get { return desc; }
            set { desc = value; }
        }
        public int ViajesDelMes { get; private set; } = 0;

        // Constructor
        public TarjetaComun(int saldo) : base(saldo)
        {
            desc = 1.0f;
        }

        // Métodos
        public void ReiniciarViajesDelMes()
        {
            ViajesDelMes = 0;
        }

        public override bool EsPosibleViajar(int tarifa)
        {
            if (Saldo + 480 < tarifa)
                return false;
            else
                return true;
        }

        public override void CalcularFranquicia()
        {
            if (ViajesDelMes >= 30 && ViajesDelMes <= 79)
            {
                Descuento_franquicia = 0.8f;
            }
            else if (ViajesDelMes >= 80)
            {
                Descuento_franquicia = 0.75f;
            }
            else
            {
                Descuento_franquicia = 1.0f;
            }
        }
        public override void RegistrarViaje()
        {
            ViajesDelMes++;
            CalcularFranquicia();
        }
    }
}