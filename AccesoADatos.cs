using System.Text.Json;
public abstract class AccesoADatos
{
    public abstract Cadeteria LeerArchivoCadeteria(string rutaArchivo);
    public abstract List<Cadete> LeerArchivoCadetes(string rutaArchivo);
}

public class AccesoCSV : AccesoADatos
{
    public override Cadeteria LeerArchivoCadeteria(string rutaArchivo)
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

    public override List<Cadete> LeerArchivoCadetes(string rutaArchivo)
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
                listaCadetes.Add(cadete);
            }
        }
        return listaCadetes;
    }
}

public class AccesoJSON : AccesoADatos
{
    public override Cadeteria LeerArchivoCadeteria(string rutaArchivo)
    {
        string jsonData = File.ReadAllText(rutaArchivo);
        return JsonSerializer.Deserialize<Cadeteria>(jsonData);
    }

    public override List<Cadete> LeerArchivoCadetes(string rutaArchivo)
    {
        string jsonData = File.ReadAllText(rutaArchivo);
        return JsonSerializer.Deserialize<List<Cadete>>(jsonData);
    }
}