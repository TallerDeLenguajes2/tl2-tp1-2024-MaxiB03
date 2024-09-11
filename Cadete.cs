public class Cadete
{
    int id;
    string nombre;
    string direccion;
    string telefono;
    List<Pedidos> listaPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    //Constructor
    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListaPedidos = new List<Pedidos> ();
    }

    //Metodos
    public void AgregarPedido(Pedidos pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public void EliminarPedido(Pedidos pedido)
    {
        ListaPedidos.Remove(pedido);
    }

    public int PedidosEntregados()
    {
        int entregados=0;

        foreach (var pedido in listaPedidos)
        {
            if(pedido.Estado == Estado.Entregado)
            {
                entregados++;
            }
        }
        return entregados;
    }

    public int JornalACobrar()
    {
        int CantEntregados;
        CantEntregados = PedidosEntregados();

        return 500*CantEntregados;
    }
}