using System.Reflection.Metadata;

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
    Console.WriteLine("3. Asignar Cadete a Pedido");
    Console.WriteLine("4. Salir");
    Console.Write("Seleccione una opción: ");
            
    string? opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            DarDeAltaPedido(cadeteria);
            break;
        case "2":
            CambiarEstado(cadeteria);
            break;
        case "3":
            AsignarCadete(cadeteria);
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

    cadeteria.AgregarPedido(nroPedido, observacion, nombreCliente, direccionCliente, telefonoCliente, datosDeReferencia, Estado.Pendiente);
    Console.WriteLine("Pedido tomado exitosamente.");
}

void CambiarEstado(Cadeteria cadeteria)
{
    int nroPedido;
    Console.WriteLine("Ingrese numero del pedido a modificar: ");

    while (!int.TryParse(Console.ReadLine(), out nroPedido))
    {
        Console.WriteLine("No ingreso un numero. Inténtelo de nuevo.");
    }

    bool encontrado = BuscarNroPedido(cadeteria.ListaPedidos, nroPedido);

    if(encontrado!=false)
    {
        cadeteria.CambiarEstadoPedido(nroPedido);
        Console.WriteLine("Estado actualizado con éxito.");
    }
    else
    {
        Console.WriteLine("Pedido No encontrado");
    }
}

void AsignarCadete(Cadeteria cadeteria)
{
    int nroPedido;
    Console.WriteLine("Ingrese numero del pedido: ");

    while (!int.TryParse(Console.ReadLine(), out nroPedido))
    {
        Console.WriteLine("No ingreso un numero. Inténtelo de nuevo.");
    }

    bool encontrado = BuscarNroPedido(cadeteria.ListaPedidos, nroPedido);

    if(encontrado!=false)
    {
        int idCadete;
        Console.WriteLine("Ingrese Id del cadete que desea asignar");

        while (!int.TryParse(Console.ReadLine(), out idCadete) || idCadete<1 || idCadete>3)
        {
            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
        }

        cadeteria.AsignarCadeteAPedido(idCadete, nroPedido);
        Console.WriteLine("Cadete asignado exitosamente");
    }
    else
    {
        Console.WriteLine("Pedido No encontrado");
    }
}

bool BuscarNroPedido(List<Pedidos> pedidos, int nroBuscado)
{
    foreach (var pedido in pedidos)
    {
        if(pedido.NroPedido==nroBuscado)
        {
            return true;
        }
    }
    return false;
}
