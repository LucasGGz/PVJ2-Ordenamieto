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

            // Cambiar color del objeto actual a verde despu�s de la comparaci�n y posible intercambio
            LeanTween.color(unsortedList[i], Color.green, 0.5f);

            // Esperar un tiempo antes de la siguiente iteraci�n
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
            yield return new WaitForSeconds(0.6f);

            while (j >= 0 && unsortedList[j].transform.localScale.y > key.transform.localScale.y)
            {
                LeanTween.color(unsortedList[j], Color.red, 0.5f);
                yield return new WaitForSeconds(0.7f);
                LeanTween.color(unsortedList[j], Color.white, 0.5f);
                LeanTween.color(key, Color.magenta, 0.5f);
                unsortedList[j + 1] = unsortedList[j];

                LeanTween.moveLocalX(unsortedList[j + 1], unsortedList[j + 1].transform.localPosition.x + 1, 0.4f);

                j = j - 1;

                yield return new WaitForSeconds(0.5f);
            }

            unsortedList[j + 1] = key;

            LeanTween.moveLocalX(key, j + 1, 0.4f);
            LeanTween.color(key, Color.green, 0.5f);

            yield return new WaitForSeconds(0.7f);

            LeanTween.color(key, Color.white, 0.1f);
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
}
