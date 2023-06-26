public class Exists
{
    public static int binarySearchOrigin(List<string> listNodes, string value)
    {
        // Ordenar Lista
        quicksort(listNodes, 0, listNodes.Count() - 1);

        return BusquedaBinariaRecursiva(listNodes, value, 0, listNodes.Count() - 1);
    }

    private static void quicksort(List<string> listNodes, int izquierda, int derecha)
    {
        if (izquierda < derecha)
        {
            int indiceParticion = particion(listNodes, izquierda, derecha);
            quicksort(listNodes, izquierda, indiceParticion);
            quicksort(listNodes, indiceParticion + 1, derecha);
        }
    }
    private static int particion(List<string> listNodes, int izquierda, int derecha)
    {
        string pivote = listNodes[izquierda];

        while (true)
        {
            // Acercar los extremos hacia el centro mientras se encuentren elementos ordenados
            while (String.Compare(listNodes[izquierda], pivote) < 0)
            {
                izquierda++;
            }

            while (String.Compare(listNodes[derecha], pivote) > 0)
            {
                derecha--;
            }

            // Si los extremos se cruzaron o superaron, entonces toda la porción del arreglo estaba ordenada
            if (izquierda >= derecha)
            {
                // Regresamos el índice para indicar hasta qué posición el arreglo está en orden
                return derecha;
            }
            else
            {
                // Si no estuvieron ordenados, vamos a hacer el intercambio
                string temporal = listNodes[izquierda];
                listNodes[izquierda] = listNodes[derecha];
                listNodes[derecha] = temporal;

                // Y acercamos en 1 los extremos
                derecha--; izquierda++;

            }
            // El while se repite hasta que izquierda >= derecha
        }
    }

    // Busqueda binaria
    private static int BusquedaBinariaRecursiva(List<string> listNodes, string value, int izquierda, int derecha)
    {
        if (izquierda > derecha)
        {
            return -1;
        }

        int medio = izquierda + (derecha - izquierda) / 2;

        if (String.Compare(listNodes[medio], value) == 0)
        {
            return medio;
        }
        else if (String.Compare(listNodes[medio], value) < 0)
        {
            return BusquedaBinariaRecursiva(listNodes, value, medio + 1, derecha);
        }
        else
        {
            return BusquedaBinariaRecursiva(listNodes, value, izquierda, medio - 1);
        }
    }

}