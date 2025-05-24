using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salirescena : MonoBehaviour
{
    public void Salir ()
{
    Application.Quit();
        Debug.Log("se ha salido del juego");
    }
}