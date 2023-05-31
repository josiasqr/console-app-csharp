class InRequestService : RequestService
{
    private static string FILE_NAME = "request.csv";
    private static string SEPARATOR = ",";
    private static string FILE = Constants.PATH + FILE_NAME;

    public void create()
    {
        Console.WriteLine("-- REGISTRO DE SOLICITUD");
        Console.WriteLine("------------------------");
        Console.WriteLine("Cuantas solicitudes desea registrar?");
        Console.Write("Cantidad: ");
        int cantitad = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < cantitad; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"- Registro N{i + 1}: ");

            Request request = new Request();
            request.Id = request.generateId();

            Console.Write("Orden: ");
            request.Order = Console.ReadLine();

            Console.Write("Solicitante: ");
            request.Applicant = Console.ReadLine();

            Console.Write("Falla: ");
            request.Failure = Console.ReadLine();

            Console.Write("Descripcion: ");
            request.Description = Console.ReadLine();

            Console.Write("Costo: ");
            request.Cost = Convert.ToDouble(Console.ReadLine());

            // Envia a registrar en archivo el 'request' generado
            newRequest(request.dataInFIle());
        }
    }

    public void read()
    {
        string separator = SEPARATOR;
        string line;
        string[] row;

        try
        {
            // Crea el archivo y lee la primera fila
            StreamReader sr = new StreamReader(FILE);
            sr.ReadLine();

            // Imprime cabecera
            Console.WriteLine("-- LISTA DE SOLICITUDES");
            Console.WriteLine(Request.printHeader());

            // Lee la siguiente fila del archivo
            while ((line = sr.ReadLine()) != null)
            {
                // Separa los datos del archivo por cada ',' como separador
                row = line.Split(separator);

                // Crea un objeto Request.cs de los datos separados por fila
                Request request = new Request();
                request.Id = row[0];
                request.Order = row[1];
                request.Applicant = row[2];
                request.Failure = row[3];
                request.Description = row[4];
                request.Cost = Convert.ToDouble(row[5]);

                // Imprime los registros del archivo
                Console.WriteLine(request.ToString());
            }

            // Cierra el archivo
            sr.Close();
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex);
        }
    }

    public void update()
    {

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