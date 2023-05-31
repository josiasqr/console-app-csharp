public class Menu
{
    public static void showMenu()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("-- SDCT | SISTEMA DE DISTRIBUCIÓN DE CARGA DE TRABAJO --");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("1. Registrar solicitud de atención.");
        Console.WriteLine("2. Ordenar registros de atención.");
        Console.WriteLine("3. Optimizar atenciones (algoritmo de la mochila).");
        Console.WriteLine("4. Buscar solicitud de atención.");
        Console.WriteLine("0. Salir");
        Console.WriteLine("");
    }

    public static string readOption()
    {
        Console.WriteLine("-----------------------");
        Console.Write("-- Elije una opción: ");
        string opcion = Console.ReadLine();
        Console.WriteLine("-----------------------");
        Console.WriteLine();
        return opcion;
    }
}