using CodigoComun.Models;
using CodigoComun.Negocio;


DepositoServices depositoServices = new DepositoServices();
List<Deposito> depositos = depositoServices.ObtenerTodosLosDepositos();

foreach (Deposito deposito in depositos)
{
    Console.WriteLine($"Id: {deposito.Id}");
    Console.WriteLine($"Nombre: {deposito.Nombre}");
    Console.WriteLine($"Direccion: {deposito.Direccion}");
    Console.WriteLine($"Capacidad: {deposito.Capacidad}");
    Console.WriteLine("----------------------");
}
