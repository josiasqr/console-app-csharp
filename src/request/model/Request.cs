class Request
{
    private string origin;
    private string destination;
    private double distance;

    public string Origin { get => origin; set => origin = value; }
    public string Destination { get => destination; set => destination = value; }
    public double Distance { get => distance; set => distance = value; }

    private static string HEADER_REGEX = "{0,-20} {1,-20} {2,-10}";

    public Request()
    {
    }

    // Genera un UUID
    public string generateId()
    {
        return Guid.NewGuid().ToString();
    }

    // Header que se registra en el archivo
    public static string headerInFIle()
    {
        return "ORIGIN" + "," + "DESTINATION" + "," + "DISTANCE";
    }

    // Datos que se registra en el arhivo
    public string dataInFIle()
    {
        return this.Origin + "," + this.Destination + "," + this.Distance;
    }

    // Header que se muestra en pantalla
    public static string printHeader()
    {
        return "--------------------------------------------------"
                + "\n"
                + String.Format(HEADER_REGEX, "ORIGIN", "DESTINATION", "DISTANCE")
                + "\n"
                + "--------------------------------------------------";
    }

    // Datos que se muestra en pantalla
    public override string ToString()
    {
        return String.Format(HEADER_REGEX, this.Origin, this.Destination, this.Distance + Constants.SPACE + Constants.UNITS_OF_LENGHT);
    }
}