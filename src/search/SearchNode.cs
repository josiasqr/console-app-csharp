class SearchNode
{
    public static void findNode(List<Request> listRequest, string value)
    {
        listRequest = find(listRequest, value);

        if (listRequest.Count() > 0)
        {
            Console.WriteLine("");
            Console.WriteLine("-- LISTA DE NODO ENCONTRADOS");
            Console.WriteLine(Request.printHeader());
            foreach (Request request in listRequest)
            {
                Console.WriteLine(request.ToString());
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine($"NOT-FOUND: El Nodo [{value}] no encontrado.");
        }
    }

    // Busqueda Sequencial del nodo tanto en [ORIGEN] [DESTINO]
    private static List<Request> find(List<Request> listRequest, string value)
    {
        List<Request> newRequest = new List<Request>();

        foreach (Request request in listRequest)
        {
            if (request.Origin.Equals(value) || request.Destination.Equals(value))
            {
                newRequest.Add(request);
            }
        }

        return newRequest;
    }
}