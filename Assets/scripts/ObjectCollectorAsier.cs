using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector_Escenario2 : MonoBehaviour
{
    public Image iconAlfombra;
    public Image iconCojin;
    public Image iconCuchillo;
    public Image iconLata;
    public Image iconMechero;
    public Image iconAjedrez;

    private int objectsCollected = 0;
    private int totalObjects = 6;

    public GameObject teleportArea;

    void Start()
    {
        teleportArea.SetActive(false);
    }

    public void Collect(string objectName)
    {
        switch (objectName)
        {
            case "Img_alfombra": iconAlfombra.color = Color.green; break;
            case "Img_cojin": iconCojin.color = Color.green; break;
            case "Img_cuchillo": iconCuchillo.color = Color.green; break;
            case "Img_lata": iconLata.color = Color.green; break;
            case "Img_mechero": iconMechero.color = Color.green; break;
            case "Img_ajedrez": iconAjedrez.color = Color.green; break;
        }

        objectsCollected++;

        if (objectsCollected == totalObjects)
        {
            teleportArea.SetActive(true);
        }
    }
}
