public class Menu
{
    public static void showMenu()
    {
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("-- EXAMEN FINAL | SISTEMA DE RUTAS ÓPTIMAS DIJKSTRA v1.0 --");
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("1. Insertar Nodos-Aristas en el archivo.");
        Console.WriteLine("2. Buscar si existe un nodo en el archivo.");
        Console.WriteLine("3. Buscar un Nodo en el archivo.");
        Console.WriteLine("4. Listar datos ordenados Ascendente por su distancia.");
        Console.WriteLine("5. Listar datos ordenados Descendente por su distancia.");
        Console.WriteLine("6. Aplicar algoritmo Dijkstra.");
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