Console.WriteLine("Seleccione el tipo de acceso a los datos:");
Console.WriteLine("1. CSV");
Console.WriteLine("2. JSON");
int respuesta;

while (!int.TryParse(Console.ReadLine(), out respuesta) || (respuesta != 1 && respuesta != 2))
{
    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
}

AccesoADatos accesoADatos;
string rutaCadeteria;
string rutaCadetes;

if (respuesta == 1)
{
    accesoADatos = new AccesoCSV();
    rutaCadeteria = "C:/RepoTaller2/tp1/tl2-tp1-2024-MaxiB03/DatosCadeteria.csv";
    rutaCadetes = "C:/RepoTaller2/tp1/tl2-tp1-2024-MaxiB03/DatosCadetes.csv";
    Console.WriteLine("Acceso a CSV seleccionado.");
}
else
{
    accesoADatos = new AccesoJSON();
    rutaCadeteria = "C:/RepoTaller2/tp1/tl2-tp1-2024-MaxiB03/DatosCadeteria.json";
    rutaCadetes = "C:/RepoTaller2/tp1/tl2-tp1-2024-MaxiB03/DatosCadetes.json";
    Console.WriteLine("Acceso a JSON seleccionado.");
}

Cadeteria cadeteria = accesoADatos.LeerArchivoCadeteria(rutaCadeteria); 
List<Cadete> listaCadetes = accesoADatos.LeerArchivoCadetes(rutaCadetes); 

// Asigno la lista de cadetes cargada a la cadetería
if (cadeteria != null)
{
    cadeteria.ListaCadetes = listaCadetes;
}

// Verificación de la carga de datos
if (cadeteria != null && cadeteria.ListaCadetes.Count > 0)
{
    Console.WriteLine("Datos de la cadetería y cadetes cargados exitosamente.");
}
else
{
    Console.WriteLine("Error al cargar los datos desde los archivos.");
    return;
}

// Menú principal
bool continuar = true;
while (continuar)
{
    Console.WriteLine("\nGestión de Pedidos:");
    Console.WriteLine("1. Dar de alta pedido");
    Console.WriteLine("2. Cambiar estado de un pedido");
    Console.WriteLine("3. Reasignar pedido a otro cadete");
    Console.WriteLine("4. Salir");
    Console.Write("Seleccione una opción: ");
            
    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            DarDeAltaPedido(cadeteria);
            break;
        case "2":
            CambiarEstadoPedido(cadeteria);
            break;
        case "3":
            ReasignarPedido(cadeteria);
            break;
        case "4":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}

Informe.GenerarInforme(cadeteria);

//Opciones Menú
void DarDeAltaPedido(Cadeteria cadeteria)
{
    int nroPedido;
    Console.Write("Ingrese el numero de pedido: ");
    while (!int.TryParse(Console.ReadLine(), out nroPedido))
    {
        Console.WriteLine("No ingreso un numero. Inténtelo de nuevo.");
    }

    Console.WriteLine("Ingrese una observación para el pedido:");
    string? observacion = Console.ReadLine();

    Console.WriteLine("Ingrese el nombre del cliente:");
    string? nombreCliente = Console.ReadLine();

    Console.WriteLine("Ingrese la dirección del cliente:");
    string? direccionCliente = Console.ReadLine();

    Console.WriteLine("Ingrese el teléfono del cliente:");
    string? telefonoCliente = Console.ReadLine();

    Console.WriteLine("Ingrese datos de referencia del cliente:");
    string? datosDeReferencia = Console.ReadLine();

    Pedidos nuevoPedido = new Pedidos(nroPedido, observacion, nombreCliente, direccionCliente, telefonoCliente, datosDeReferencia, Estado.Pendiente);

    int idCadete;
    Cadete cadeteAsignado;
    do
    {
        Console.WriteLine("Ingrese el ID del cadete para asignar el pedido:");

        while (!int.TryParse(Console.ReadLine(), out idCadete))
        {
            Console.WriteLine("No ingreso un numero. Inténtelo de nuevo.");
        }
        
        cadeteAsignado = BuscarCadetePorID(cadeteria.ListaCadetes, idCadete);

        if(cadeteAsignado==null)
        {
            Console.WriteLine("No se encontro cadete con ese ID");
        }

    } while (cadeteAsignado==null);

    cadeteria.AsignarPedidoACadete(cadeteAsignado, nuevoPedido);
    Console.WriteLine("Pedido asignado al cadete exitosamente.");
}

void CambiarEstadoPedido(Cadeteria cadeteria)
{
    int nroPedido;
    Console.WriteLine("Ingrese el número del pedido a modificar: ");

    while (!int.TryParse(Console.ReadLine(), out nroPedido))
    {
        Console.WriteLine("No ingreso un numero. Inténtelo de nuevo.");
    }

    Pedidos pedido = BuscarPedidoEnCadetes(cadeteria.ListaCadetes, nroPedido);

    if(pedido!=null)
    {
        int nuevoEstado;
        Console.WriteLine("Ingrese el nuevo estado (0: Pendiente, 1: Entregado, 2: Cancelado):");

        while (!int.TryParse(Console.ReadLine(), out nuevoEstado) || nuevoEstado < 0 || nuevoEstado > 2)
        {
            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
        }

        switch (nuevoEstado)
        {
            case 0:
                pedido.Estado = Estado.Pendiente;
            break;
            case 1:
                pedido.Estado = Estado.Entregado;
            break;
            case 2:
                pedido.Estado = Estado.Cancelado;
            break;
        }

        Console.WriteLine("Estado actualizado con éxito.");
    }
    else
    {
        Console.WriteLine("Pedido no encontrado.");
    }
}

void ReasignarPedido(Cadeteria cadeteria)
{
    int nroPedido;
    Console.WriteLine("Ingrese numero del pedido a reasignar:");

    while (!int.TryParse(Console.ReadLine(), out nroPedido))
    {
        Console.WriteLine("No Ingreso un numero. Inténtelo de nuevo.");
    }

    Pedidos pedido = BuscarPedidoEnCadetes(cadeteria.ListaCadetes, nroPedido);

    if(pedido!=null)
    {
        Cadete cadeteActual = BuscarCadeteActual(cadeteria.ListaCadetes, nroPedido);
        Console.WriteLine($"Cadete que posee el pedido \nId:{cadeteActual.Id}, Nombre: {cadeteActual.Nombre}");

        int idNuevoCadete;
        Console.WriteLine("Ingrese ID del nuevo cadete");

        while (!int.TryParse(Console.ReadLine(), out idNuevoCadete) || idNuevoCadete==cadeteActual.Id || idNuevoCadete < 0 || idNuevoCadete > 2)
        {
            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
        }

        Cadete cadeteNuevo = BuscarCadetePorID(cadeteria.ListaCadetes, idNuevoCadete);

        cadeteria.ReasignarPedido(cadeteActual, cadeteNuevo, pedido);
        Console.WriteLine("Pedido Reasignado exitosamente");
    }
    else
    {
        Console.WriteLine("Pedido no encontrado.");
    }
}

Cadete BuscarCadeteActual(List<Cadete> cadetes, int nroBuscado)
{
    foreach (var cadete in cadetes)
    {
        foreach (var pedido in cadete.ListaPedidos)
        {
            if(pedido.NroPedido==nroBuscado)
            {
                return cadete;
            }
        }
    }
    return null;
}

Pedidos BuscarPedidoEnCadetes(List<Cadete> cadetes, int nroBuscado)
{
    foreach (var cadete in cadetes)
    {
        foreach (var pedido in cadete.ListaPedidos)
        {
            if(pedido.NroPedido==nroBuscado)
            {
                return pedido;
            }
        }
    }
    return null;
}

Cadete BuscarCadetePorID(List<Cadete> cadetes, int id)
{
    Cadete encontrado;

    foreach (var cadete in cadetes)
    {
        if(cadete.Id==id)
        {
            encontrado = cadete;
            return encontrado;
        }
    }
    return null;
}
