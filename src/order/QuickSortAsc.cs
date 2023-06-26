class QuickSortAsc
{
    public static List<Request> sortAsc(List<Request> listNodes)
    {
        // Ordenar Lista
        quicksort(listNodes, 0, listNodes.Count() - 1);

        return listNodes;
    }

    private static void quicksort(List<Request> listNodes, int izquierda, int derecha)
    {
        if (izquierda < derecha)
        {
            int indiceParticion = particion(listNodes, izquierda, derecha);
            quicksort(listNodes, izquierda, indiceParticion);
            quicksort(listNodes, indiceParticion + 1, derecha);
        }
    }
    private static int particion(List<Request> listNodes, int izquierda, int derecha)
    {
        double pivote = listNodes[izquierda].Distance;

        while (true)
        {
            // Acercar los extremos hacia el centro mientras se encuentren elementos ordenados
            while (listNodes[izquierda].Distance < pivote)
            {
                izquierda++;
            }

            while (listNodes[derecha].Distance > pivote)
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
                string temporal = listNodes[izquierda].Origin;
                listNodes[izquierda].Origin = listNodes[derecha].Origin;
                listNodes[derecha].Origin = temporal;

                string temporal2 = listNodes[izquierda].Destination;
                listNodes[izquierda].Destination = listNodes[derecha].Destination;
                listNodes[derecha].Destination = temporal2;

                double temporal3 = listNodes[izquierda].Distance;
                listNodes[izquierda].Distance = listNodes[derecha].Distance;
                listNodes[derecha].Distance = temporal3;

                // Y acercamos en 1 los extremos
                derecha--; izquierda++;

            }
            // El while se repite hasta que izquierda >= derecha
        }
    }
}