using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordenamiento : MonoBehaviour
{
    public int NumberOfCubes = 7;
    public int CubeHeightMax = 10;
    public GameObject[] Cubes;

    public void StartSort()
    {
        InitializeRandom();
        StartCoroutine(SelectiornSort(Cubes));

    }

    public void StartIncer()
    {
        InitializeRandom();
        StartCoroutine(InsertionSort(Cubes));

    }
  
    public void StartBubble()
    {
        InitializeRandom();
        StartCoroutine(BubbleSort(Cubes));

    }

      public void StartQuickSort()
  {
      InitializeRandom();
      StartCoroutine(QuickSort(Cubes, 0, Cubes.Length - 1));
  }


    IEnumerator SelectiornSort(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPos;
        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;
            // Cambiar color del objeto actual a azul
            LeanTween.color(unsortedList[i], Color.blue, 0.5f);
            yield return new WaitForSeconds(0.7f);
            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                // Cambiar color del objeto actual a verde mientras se compara
                LeanTween.color(unsortedList[j], Color.green, 0.5f);

                yield return new WaitForSeconds(0.7f);

                // Restaurar el color del objeto comparado
                LeanTween.color(unsortedList[j], Color.white, 0.1f);
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    min = j;
                    LeanTween.color(unsortedList[min], Color.magenta, 0.4f);
                    yield return new WaitForSeconds(0.4f);
                    LeanTween.color(unsortedList[min], Color.white, 0.5f);
                }
            }

            if (min != i)
            {
                LeanTween.color(unsortedList[min], Color.magenta, 0.6f);
                yield return new WaitForSeconds(0.7f);
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;

                tempPos = unsortedList[i].transform.localPosition;
                LeanTween.moveLocalX(unsortedList[i], unsortedList[min].transform.localPosition.x, 1);
                LeanTween.moveLocalZ(unsortedList[i], -3, .5f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortedList[min], tempPos.x, 1);
                LeanTween.moveLocalZ(unsortedList[min], 3, .5f).setLoopPingPong(1);
            }

            // Cambiar color del objeto actual a verde después de la comparación y posible intercambio
            LeanTween.color(unsortedList[i], Color.green, 0.5f);

            // Esperar un tiempo antes de la siguiente iteración
            yield return new WaitForSeconds(0.7f);

            // Restaurar el color del objeto seleccionado
            LeanTween.color(unsortedList[min], Color.white, 0.1f);

            // Restaurar el color del objeto actual
            LeanTween.color(unsortedList[i], Color.white, 0.1f);

        }
    }
    IEnumerator InsertionSort(GameObject[] unsortedList)
    {
        int n = unsortedList.Length;

        for (int i = 1; i < n; i++)
        {
            GameObject key = unsortedList[i];
            int j = i - 1;
            LeanTween.color(key, Color.blue, 0.5f);
            yield return new WaitForSeconds(0.5f);

            while (j >= 0 && unsortedList[j].transform.localScale.y > key.transform.localScale.y)
            {
                LeanTween.color(unsortedList[j], Color.red, 0.5f);
                yield return new WaitForSeconds(0.7f);
                LeanTween.color(unsortedList[j], Color.white, 0.5f);
                LeanTween.color(key, Color.magenta, 0.6f);
                GameObject temp = unsortedList[j];
                unsortedList[j] = unsortedList[j + 1];
                unsortedList[j + 1] = temp;

                LeanTween.moveLocalX(unsortedList[j + 1], unsortedList[j + 1].transform.localPosition.x + 1, 0.4f);

                j = j - 1;

                yield return new WaitForSeconds(0.6f);
            }

            unsortedList[j + 1] = key;

            LeanTween.moveLocalX(key, j + 1, 0.4f);
            LeanTween.color(key, Color.green, 0.5f);

            yield return new WaitForSeconds(0.7f);

            LeanTween.color(key, Color.white, 0.1f);
        }
    }

    IEnumerator BubbleSort(GameObject[] unsortedList)
    {

        int n = unsortedList.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                // Cambiar color del objeto actual a azul
                LeanTween.color(unsortedList[j], Color.blue, 0.5f);
                LeanTween.color(unsortedList[j + 1], Color.blue, 0.5f);
                yield return new WaitForSeconds(0.7f);

                // Restaurar el color del objeto comparado
                LeanTween.color(unsortedList[j], Color.white, 0.1f);
                LeanTween.color(unsortedList[j + 1], Color.white, 0.1f);

                if (unsortedList[j].transform.localScale.y > unsortedList[j + 1].transform.localScale.y)
                {
                    // Intercambio de elementos
                    GameObject temp = unsortedList[j];
                    unsortedList[j] = unsortedList[j + 1];
                    unsortedList[j + 1] = temp;

                    // Animación de intercambio
                    float tempX = unsortedList[j].transform.localPosition.x;
                    LeanTween.moveLocalX(unsortedList[j], unsortedList[j + 1].transform.localPosition.x, 0.5f);
                    LeanTween.moveLocalX(unsortedList[j + 1], tempX, 0.5f);

                    // Cambiar color del objeto actual a magenta después del intercambio
                    LeanTween.color(unsortedList[j], Color.magenta, 0.6f);
                    yield return new WaitForSeconds(0.7f);
                    LeanTween.color(unsortedList[j], Color.white, 0.5f);

                    // Cambiar color del objeto siguiente a magenta después del intercambio
                    LeanTween.color(unsortedList[j + 1], Color.magenta, 0.6f);
                    yield return new WaitForSeconds(0.7f);
                    LeanTween.color(unsortedList[j + 1], Color.white, 0.5f);

                    swapped = true;
                }
            }

            // Si no se realizaron intercambios en esta iteración, la lista está ordenada
            if (!swapped)
                break;
        }
    }

    void InitializeRandom()
    {
        Cubes = new GameObject[NumberOfCubes];
        for (int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            cube.transform.position = new Vector3(i, randomNumber / 2f, 0);
            cube.transform.parent = this.transform;
            Cubes[i] = cube;
        }
        transform.position = new Vector3(-NumberOfCubes / 2f, -CubeHeightMax / 2f, 0);

    }
IEnumerator QuickSort(GameObject[] arr, int low, int high)
{
    if (low < high)
    {
        yield return StartCoroutine(Partition(arr, low, high));
    }
}

IEnumerator Partition(GameObject[] arr, int low, int high)
{
    GameObject pivot = arr[high];
    int i = low - 1;

    for (int j = low; j < high; j++)
    {
        LeanTween.color(arr[high], Color.blue, 0.5f);
        LeanTween.color(arr[j], Color.green, 0.5f);
        yield return new WaitForSeconds(0.7f);
        LeanTween.color(arr[j], Color.white, 0.1f);

        if (arr[j].transform.localScale.y < pivot.transform.localScale.y)
        {
            i++;
            GameObject temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            // Animaciones para el intercambio de los cubos
            MoverCubo(arr[i], i);
            MoverCubo(arr[j], j);

                LeanTween.color(arr[i], Color.white, 0.1f);
                yield return new WaitForSeconds(0.7f);
        }
    }

    GameObject tempPivot = arr[i + 1];
    arr[i + 1] = arr[high];
    arr[high] = tempPivot;

    // Animaciones para el intercambio del pivote
    MoverCubo(arr[i + 1], i + 1);
    MoverCubo(arr[high], high);

        LeanTween.color(arr[i + 1], Color.green, 0.5f);
        yield return new WaitForSeconds(0.7f);
        LeanTween.color(arr[i + 1], Color.white, 0.1f);
        LeanTween.color(arr[high], Color.white, 0.1f);

        int partitionIndex = i + 1;

    yield return StartCoroutine(QuickSort(arr, low, partitionIndex - 1));
    yield return StartCoroutine(QuickSort(arr, partitionIndex + 1, high));
}

void MoverCubo(GameObject cubo, int nuevaPosicion)
{
    Vector3 posicionObjetivo = new Vector3(nuevaPosicion, cubo.transform.localScale.y / 2f, 0);

    // Animación para mover el cubo
    LeanTween.moveLocal(cubo, posicionObjetivo, 0.5f);
}

}
