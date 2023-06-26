class Program
{
    public static void Main(string[] args)
    {
        bool end = false;

        do
        {
            Console.Clear();
            Menu.showMenu();
            end = option(Menu.readOption(), end);
        } while (!end);
    }

    // Opciones del menú
    static bool option(string option, bool end)
    {
        RequestService requestService = new InRequestService();

        switch (option)
        {
            case "1":
                // 1.Insertar Nodos - Aristas en el archivo.
                requestService.create();

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;

            case "2":
                // 2. Buscar si existe un nodo en el archivo.
                List<string> listString = new List<string>();

                foreach (Request request in requestService.read())
                {
                    listString.Add(request.Origin);
                    listString.Add(request.Destination);
                }

                // Ingresando valor a buscar
                Console.Write("Ingrese Nodo a buscar: ");
                string search = Console.ReadLine();

                // Busqueda Binaria
                int indice = Exists.binarySearchOrigin(listString, search);

                if (indice != -1)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"FOUND: El Nodo [{search}] si se encuentra en el archivo.");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"NOT-FOUND: Producto [{search}] no encontrado.");
                }


                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;

            case "3":
                // 3. Buscar un Nodo en el archivo.

                // Ingresando valor a buscar
                Console.Write("Ingrese Nodo a buscar: ");
                string node = Console.ReadLine();

                // Busca el nodo ingresado en origen y destino
                SearchNode.findNode(requestService.read(), node);

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;

            case "4":
                // 4. Listar datos ordenados Ascendente por su distancia.

                // Imprime cabecera
                Console.WriteLine("-- LISTA DE DATOS ORDENADOS ASCENDENTE");
                Console.WriteLine(Request.printHeader());

                foreach (Request request in QuickSortAsc.sortAsc(requestService.read()))
                {
                    // Imprime los registros del archivo
                    Console.WriteLine(request.ToString());
                }

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;

            case "5":
                // 5. Listar datos ordenados Descendente por su distancia.

                // Imprime cabecera
                Console.WriteLine("-- LISTA DE DATOS ORDENADOS DESCENDENTE");
                Console.WriteLine(Request.printHeader());

                foreach (Request request in QuickSortDesc.sortDesc(requestService.read()))
                {
                    // Imprime los registros del archivo
                    Console.WriteLine(request.ToString());
                }

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;

            case "6":
                // 6. Aplicar algoritmo Dijkstra.

                DijkstraAlgorithm dijkstra = new DijkstraAlgorithm();

                foreach (Request request in requestService.read())
                {
                    dijkstra.AddEdge(request.Origin, request.Destination, request.Distance);
                }

                string source = "Stuttgart";
                string destination = "Hanover";

                List<List<string>> paths = dijkstra.FindAllPaths(source, destination);

                Console.WriteLine("Rutas posibles desde el nodo " + source + " hasta el nodo " + destination + ":");
                if (paths.Count > 0)
                {
                    foreach (var path in paths)
                    {
                        double distance = dijkstra.CalculateDistance(path);
                        Console.WriteLine(string.Join(" -> ", path) + " (Distancia: " + distance + Constants.SPACE + Constants.UNITS_OF_LENGHT + ")");
                    }
                }
                else
                {
                    Console.WriteLine("No hay rutas disponibles.");
                }


                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;

            case "0":
                end = true;

                Console.WriteLine("Saliendo del sistema...");
                Console.WriteLine();
                break;

            default:
                Console.WriteLine("WARNING: Opción inválida, presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;
        }

        return end;
    }
}