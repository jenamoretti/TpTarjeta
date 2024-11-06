using System;
using Iteraciones;

public abstract class Colectivo
{
    public string Linea { get; private set; }

    protected Colectivo(string linea)
    {
        this.Linea = linea;
    }

    public abstract float ObtenerTarifa();

    public virtual Boleto? pagarCon(Tarjeta tarjeta)
    {
        tarjeta.CalcularFranquicia();

        float tarifa = ObtenerTarifa();
        Boleto boleto = new Boleto(tarjeta, this, tarifa);

        int costo = (int)(tarifa * tarjeta.Descuento_franquicia);

        if (!tarjeta.EsPosibleViajar(costo))
        {
            return null;
        }

        tarjeta.Pagar(costo);
        tarjeta.CantUsosHoy++;
        boleto.SaldoRestante = tarjeta.Saldo;
        tarjeta.AgregarBoleto(boleto);
        tarjeta.RegistrarViaje();

        if (tarjeta.DeudaPaga > 0)
        {
            boleto.Descripcion = $"El boleto abonó {tarjeta.DeudaPaga} pesos de saldo negativo en la última carga";
            tarjeta.DeudaPaga = 0;
        }
        else
        {
            boleto.Descripcion = null;
        }

        return boleto;
    }
}