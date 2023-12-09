using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuOrdenamiento : MonoBehaviour
{
    public Ordenamiento ordenamiento;
    public Ordenamiento activarOrdenamiento;
    public TMP_InputField inputFieldNumberOfCubes;
    public void StartSort()
    {
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        activarOrdenamiento.StartSort();
    }

    public void StartInser()
    {
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        activarOrdenamiento.StartIncer();
    }
    public void StartBubble()
    {
        activarOrdenamiento = Instantiate(ordenamiento);
        activarOrdenamiento.NumberOfCubes = Convert.ToInt16(inputFieldNumberOfCubes.text);
        activarOrdenamiento.StartBubble();
    }
    public void ResetSort()
    {
        Destroy(activarOrdenamiento.gameObject);
    }
}
