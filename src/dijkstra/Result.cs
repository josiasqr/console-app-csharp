public class Result
{
    private static string FILE_NAME = "result.csv";
    private static string FILE = Constants.PATH + FILE_NAME;

    public static void createResult(string request)
    {
        // Valida si existe el archivo
        if (!File.Exists(FILE))
        {
            // Crea el achivo y escribe la cabecera
            StreamWriter swr = File.AppendText(FILE);
            swr.WriteLine(headerInFIle());
            // Cierra el archivo
            swr.Close();
        }
        // Escribe el registro en el archivo
        StreamWriter sw = File.AppendText(FILE);
        sw.WriteLine(request);
        // Cierra el archivo
        sw.Close();
    }

    private static string headerInFIle()
    {
        return "ROUTE" + "," + "DISTANCE";
    }
}