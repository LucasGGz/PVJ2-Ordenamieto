using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordenamiento : MonoBehaviour
{
    public int NumberOfCubes = 7;
    public int CubeHeightMax = 10;
    public GameObject[] Cubes;

    private void Start()
    {
        InitializeRandom();
        StartCoroutine(SelectiornSort(Cubes));

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
            yield return new WaitForSeconds(1);
            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                // Cambiar color del objeto actual a verde mientras se compara
                LeanTween.color(unsortedList[j], Color.green, 0.5f);

                yield return new WaitForSeconds(1);

                // Restaurar el color del objeto comparado
                LeanTween.color(unsortedList[j], Color.white, 0.1f);
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    min = j;
                    LeanTween.color(unsortedList[min], Color.magenta, 0.1f);
                }

            }

            if (min != i)
            {
                yield return new WaitForSeconds(1);
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
            yield return new WaitForSeconds(1);

            // Restaurar el color del objeto seleccionado
            LeanTween.color(unsortedList[min], Color.white, 0.1f);

            // Restaurar el color del objeto actual
            LeanTween.color(unsortedList[i], Color.white, 0.1f);

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
