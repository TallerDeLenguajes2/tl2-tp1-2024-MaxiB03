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
}