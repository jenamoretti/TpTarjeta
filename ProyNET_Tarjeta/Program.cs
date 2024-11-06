// See https://aka.ms/new-console-template for more information
using System;
using Iteraciones;
class Program {
  public static void Main (string[] args) {
    Colectivo cole = new Colectivo("212");
    
    Console.WriteLine("\n Test medio boleto actualizado");
    FranquiciaCompleta tarjetaFC1 = new FranquiciaCompleta(1000);
    Boleto boletoFC1 = cole.pagarCon(tarjetaFC1);
    if (boletoFC1 != null)
      Console.WriteLine("boleto pago exitosamente");
      Console.WriteLine($"boleto {tarjetaFC1.CantUsosHoy} ,descuento franquicia: {tarjetaFC1.Descuento_franquicia}");
    Boleto boletoFC2 = cole.pagarCon(tarjetaFC1);
    if (boletoFC2 != null)
      Console.WriteLine("boleto pago exitosamente");
      Console.WriteLine($"boleto {tarjetaFC1.CantUsosHoy} ,descuento franquicia: {tarjetaFC1.Descuento_franquicia}");
    Boleto boletoFC3 = cole.pagarCon(tarjetaFC1);
    if (boletoFC3 != null)
      Console.WriteLine("boleto pago exitosamente");
    if (boletoFC3 == null)
      Console.WriteLine("boleto no fue creado ya que el segundo viaje dejo de ser gratis");
    DateTime fechaex = boletoFC3.GetFecha();
    Console.WriteLine($"boleto {tarjetaFC1.CantUsosHoy} ,descuento franquicia: {tarjetaFC1.Descuento_franquicia}, fecha :{fechaex}");
  }
}