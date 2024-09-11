public class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listaCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes;  set => listaCadetes = value; }

    //Contructor
    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListaCadetes = new List<Cadete>();
    }

    //Metodos
    public void AgregarCadete (Cadete cadete)
    {
        ListaCadetes.Add(cadete);
    }

     public void EliminarCadete(Cadete cadete)
    {
        ListaCadetes.Remove(cadete);
    }

    public void AsignarPedidoACadete(Cadete cadete, Pedidos pedido)
    {
        cadete.AgregarPedido(pedido);
    }

    public void ReasignarPedido(Cadete cadeteActual, Cadete nuevoCadete, Pedidos pedido)
    {
        cadeteActual.EliminarPedido(pedido);
        nuevoCadete.AgregarPedido(pedido);
    }
}