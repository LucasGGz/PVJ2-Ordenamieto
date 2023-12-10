using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;  
using System;

public class MenuOrdenamiento : MonoBehaviour
{
    public Ordenamiento ordenamiento;  // Referencia a la clase de ordenamiento
    public Ordenamiento activarOrdenamiento;  // Instancia de la clase de ordenamiento activa
    public TMP_InputField inputFieldNumberOfCubes;  // Campo de entrada para el número de cubos

    // Método para iniciar el algoritmo de ordenamiento de selección
    public void StartSort()
    {
        // Instanciar la clase de ordenamiento y configurar el número de cubos
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        // Iniciar el algoritmo de ordenamiento de selección
        activarOrdenamiento.StartSort();
    }

    // Método para iniciar el algoritmo de ordenamiento de inserción
    public void StartInser()
    {
        // Instanciar la clase de ordenamiento y configurar el número de cubos
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        // Iniciar el algoritmo de ordenamiento de inserción
        activarOrdenamiento.StartIncer();
    }

    // Método para iniciar el algoritmo de ordenamiento de burbuja
    public void StartBubble()
    {
        // Instanciar la clase de ordenamiento y configurar el número de cubos
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        // Iniciar el algoritmo de ordenamiento de burbuja
        activarOrdenamiento.StartBubble();
    }

    // Método para iniciar el algoritmo de quicksort
    public void StartQuickSort()
    {
        // Instanciar la clase de ordenamiento y configurar el número de cubos
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        // Iniciar el algoritmo de quicksort
        activarOrdenamiento.StartQuickSort();
    }

    // Método para reiniciar el algoritmo de ordenamiento
    public void ResetSort()
    {
        // Destruir la instancia activa de la clase de ordenamiento
        Destroy(activarOrdenamiento.gameObject);
    }
}
