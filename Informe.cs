public static class Informe
{
    public static void GenerarInforme(Cadeteria cadeteria)
    {
        // Creo un objeto por cada cadete con su Nombre, Cantidad de Pedidos y MontoGanado
        var informeCadetes = cadeteria.ListaCadetes.Select(cadete => new
        {
            Nombre = cadete.Nombre,
            CantidadPedidos = cadete.ListaPedidos.Count,
            MontoGanado = cadete.JornalACobrar()
        }).ToList(); // Con ToList() guardo cada objeto creado en una nueva lista (informeCadetes)

        // Mostrar el informe por cada cadete
        Console.WriteLine("Informe de jornada:\n");
        foreach (var cadeteInfo in informeCadetes)
        {
            Console.WriteLine($"Cadete: {cadeteInfo.Nombre}");
            Console.WriteLine($"Cantidad de pedidos: {cadeteInfo.CantidadPedidos}");
            Console.WriteLine($"Monto ganado: ${cadeteInfo.MontoGanado}");
            Console.WriteLine("-------------------------");
        }

        // (Sum) suma la coleccion completa y (Average) devuelve el promedio de la misma
        int totalPedidos = informeCadetes.Sum(c => c.CantidadPedidos);
        double promedioPedidos = informeCadetes.Average(c => c.CantidadPedidos);

        Console.WriteLine($"Total de pedidos: {totalPedidos}");
        Console.WriteLine($"Promedio de pedidos por cadete: {promedioPedidos:F2}");
    }
}