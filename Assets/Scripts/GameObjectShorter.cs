using System.Collections;
using UnityEngine;

public class GameObjectSorter : MonoBehaviour
{
    public GameObject[] gameObjects;
    public float sortingSpeed = 1f;

    void Start()
    {
        StartCoroutine(BubbleSort());
    }

    IEnumerator BubbleSort()
    {
        int n = gameObjects.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Compara las posiciones en el eje Y de los Game Objects
                if (gameObjects[j].transform.position.y < gameObjects[j + 1].transform.position.y)
                {
                    // Intercambia los Game Objects en la lista
                    GameObject temp = gameObjects[j];
                    gameObjects[j] = gameObjects[j + 1];
                    gameObjects[j + 1] = temp;

                    // Mueve visualmente los Game Objects para reflejar el intercambio
                    StartCoroutine(MoveObjects(gameObjects[j].transform, gameObjects[j + 1].transform));

                    yield return new WaitForSeconds(sortingSpeed);
                }
            }
        }

        Debug.Log("Ordenamiento completado");
    }

    IEnumerator MoveObjects(Transform object1, Transform object2)
    {
        Vector3 targetPos1 = object2.position;
        Vector3 targetPos2 = object1.position;

        float startTime = Time.time;
        float journeyLength = Vector3.Distance(object1.position, targetPos1);

        while (Time.time - startTime < sortingSpeed)
        {
            float distCovered = (Time.time - startTime) * sortingSpeed;
            float fracJourney = distCovered / journeyLength;

            object1.position = Vector3.Lerp(object1.position, targetPos1, fracJourney);
            object2.position = Vector3.Lerp(object2.position, targetPos2, fracJourney);

            yield return null;
        }

        // Ajusta las posiciones para asegurarse de que estén exactamente en el destino
        object1.position = targetPos1;
        object2.position = targetPos2;
    }
}
