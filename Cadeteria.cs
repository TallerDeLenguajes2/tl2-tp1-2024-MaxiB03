public class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listaCadetes;
    List<Pedidos> listaPedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes;  set => listaCadetes = value; }
    public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    //Contructor
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListaCadetes = new List<Cadete>();
        listaPedidos = new List<Pedidos>();
    }

    //Metodos
    public void AgregarPedido(int nroPedido, string observacion, string nombreCli, string direccion, string telefono, string datosDeReferencia,  Estado estado)
    {
        Pedidos nuevoPedido = new Pedidos(nroPedido, observacion, nombreCli, direccion, telefono, datosDeReferencia, estado);
        ListaPedidos.Add(nuevoPedido);
    }
    public void AgregarCadete (Cadete cadete)
    {
        ListaCadetes.Add(cadete);
    }

     public void EliminarCadete(Cadete cadete)
    {
        ListaCadetes.Remove(cadete);
    }

    public int JornalACobrar(int idCadete)
    {
        int cantPedidos=0;
        
        foreach (var pedido in listaPedidos)
        {
            if(pedido.IdCadete==idCadete && pedido.Estado==Estado.Entregado)
            {
                cantPedidos++;
            }
        }
        return cantPedidos*500;
    }

    public void CambiarEstadoPedido(int nroPedido)
    {
        int nuevoEstado;
        Console.WriteLine("Ingrese el nuevo estado (0: Pendiente, 1: Entregado, 2: Cancelado):");

        while (!int.TryParse(Console.ReadLine(), out nuevoEstado) || nuevoEstado < 0 || nuevoEstado > 2)
        {
            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
        }

        Pedidos? pedidoEncontrado=null;
        foreach (var pedido in listaPedidos)
        {
            if(pedido.NroPedido==nroPedido)
            {
                pedidoEncontrado = pedido;
            }
        }

        switch (nuevoEstado)
        {
            case 0:
                pedidoEncontrado.Estado = Estado.Pendiente;
            break;
            case 1:
                pedidoEncontrado.Estado = Estado.Entregado;
            break;
            case 2:
                pedidoEncontrado.Estado = Estado.Cancelado;
            break;
        }
    }

    public void AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        foreach (var pedido in listaPedidos)
        {
            if(pedido.NroPedido==nroPedido)
            {
                pedido.IdCadete = idCadete;
            }
        }
    }
}