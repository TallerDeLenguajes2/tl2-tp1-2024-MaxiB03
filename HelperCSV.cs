public static class CsvHelper
{
    // Método para cargar la información de la cadetería desde un archivo CSV
    public static Cadeteria CargarCadeteriaDesdeCSV(string rutaArchivo)
    {
        using (StreamReader lector = new StreamReader(rutaArchivo))
        {
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine();
                string[] datos = linea.Split(',');
                
                string nombre = datos[0].Trim();
                string telefono = datos[1].Trim();

                return new Cadeteria(nombre, telefono);
            }
        }
        return null;
    }

    // Método para cargar los cadetes desde un archivo CSV
    public static List<Cadete> CargarCadetesDesdeCSV(string rutaArchivo)
    {
        List<Cadete> listaCadetes = new List<Cadete>();

        using (StreamReader lector = new StreamReader(rutaArchivo))
        {
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine();
                string[] datos = linea.Split(',');

                int id = int.Parse(datos[0].Trim());
                string nombre = datos[1].Trim();
                string direccion = datos[2].Trim();
                string telefono = datos[3].Trim();

                Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                listaCadetes.Add(cadete);  // Agregar cadete a la lista
            }
        }
        return listaCadetes;
    }
}