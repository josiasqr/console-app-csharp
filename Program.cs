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
                requestService.create();

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;
            case "2":
                requestService.read();

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;
            case "3":
                Console.WriteLine("Opción 3");

                Console.WriteLine("");
                Console.WriteLine("INFO: Presiona 'ENTER' para volver a mostrar el menú.");
                Console.ReadLine();
                break;
            case "4":
                Console.WriteLine("Opción 4");

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