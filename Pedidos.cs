enum Estado {Pendiente, Entegado, Cancelado}
public class Pedidos
{
    int nroPedido;
    string observacion;
    Cliente cliente;
    Estado estado;

    public int NroPedido { get => nroPedido; set => nroPedido = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    internal Estado Estado { get => estado; set => estado = value; }
}