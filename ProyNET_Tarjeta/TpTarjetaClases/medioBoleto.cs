using System;
using System.Collections.Generic;
using System.Linq;

namespace Iteraciones
{
    public class MedioBoleto : Tarjeta
    {
        // Atributos
        private float desc;

        public override float Descuento_franquicia
        {
            get { return desc; }
            set { desc = value; }
        }

        // Constructor
        public MedioBoleto(int saldo) : base(saldo)
        {
            desc = 0.5f;
        }

        // Métodos
        public override bool EsPosibleViajar(int tarifa)
        {
            if (Saldo + 480 < tarifa || !EsHorarioValido())
                return false;

            Boleto ult_bol = boletos_pagos.LastOrDefault();
            if (ult_bol != null)
            {
                TimeSpan dif = Tarjeta.tiempo.Now() - ult_bol.GetFecha();
                if (dif.TotalMinutes < 5)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        public override void CalcularFranquicia()
        {
            if (CantUsosHoy < 4)
                Descuento_franquicia = 0.5f;
            else
                Descuento_franquicia = 1.0f;
        }
    }
}