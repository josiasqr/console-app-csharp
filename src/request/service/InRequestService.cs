class InRequestService : RequestService
{
    private static string FILE_NAME = "request.csv";
    private static string SEPARATOR = ",";
    private static string FILE = Constants.PATH + FILE_NAME;

    public void create()
    {
        Console.WriteLine("-- REGISTRO DE NODOS-ARISTAS");
        Console.WriteLine("------------------------");
        Request request = new Request();

        Console.Write("Origin: ");
        request.Origin = Console.ReadLine();

        Console.Write("Destination: ");
        request.Destination = Console.ReadLine();

        Console.Write("Distance: ");
        request.Distance = Convert.ToDouble(Console.ReadLine());

        // Envia a registrar en archivo el 'request' generado
        newRequest(request.dataInFIle());
    }

    public List<Request> read()
    {
        string separator = SEPARATOR;
        string line;
        string[] row;

        try
        {
            // Crea el archivo y lee la primera fila
            StreamReader sr = new StreamReader(FILE);
            sr.ReadLine();

            // Se crea la lista de request que va a devolver
            List<Request> listRequest = new List<Request>();

            // Lee la siguiente fila del archivo
            while ((line = sr.ReadLine()) != null)
            {
                // Separa los datos del archivo por cada ',' como separador
                row = line.Split(separator);

                // Crea un objeto Request.cs de los datos separados por fila
                Request request = new Request();
                request.Origin = row[0];
                request.Destination = row[1];
                request.Distance = Convert.ToDouble(row[2]);

                // Agrega el request a la lista
                listRequest.Add(request);
            }
            // Cierra el archivo
            sr.Close();

            return listRequest;
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex);
            return new List<Request>();
        }
    }

    void newRequest(string request)
    {
        // Valida si existe el archivo
        if (!File.Exists(FILE))
        {
            // Crea el achivo y escribe la cabecera
            StreamWriter swr = File.AppendText(FILE);
            swr.WriteLine(Request.headerInFIle());
            // Cierra el archivo
            swr.Close();
        }

        // Escribe el registro en el archivo
        StreamWriter sw = File.AppendText(FILE);
        sw.WriteLine(request);
        // Cierra el archivo
        sw.Close();
    }
}