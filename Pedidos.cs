public enum Estado {Pendiente, Entregado, Cancelado}
public class Pedidos
{
    int nroPedido;
    string observacion;
    Cliente cliente;
    Estado estado;

    public int NroPedido { get => nroPedido; private set => nroPedido = value; }
    public string Observacion { get => observacion; private set => observacion = value; }
    internal Estado Estado { get => estado;  set => estado = value; }
    public Cliente Cliente { get => cliente; private set => cliente = value; }

    public Pedidos (int nroPedido, string observacion, string nombreCli, string direccion, string telefono, string datosDeReferencia,  Estado estado)
    {
        NroPedido = nroPedido;
        Observacion = observacion;
        Estado = estado;

        // Inicializo un nuevo Cliente dentro del Pedido (composición)
        Cliente = new Cliente(nombreCli, direccion, telefono, datosDeReferencia);
    }

    //Metodos
    public string VerDireccionCliente()
    {
        return $"Dirección: {Cliente.Direccion}, Referencia: {Cliente.DatosDeReferencia}";
    }

    public string VerDatosCliente()
    {
        return $"Nombre: {Cliente.Nombre}, Telefono: {Cliente.Telefono}";
    }
}