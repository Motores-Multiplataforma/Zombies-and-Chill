using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectCollector : MonoBehaviour
{
    public Image iconEstatua;
    public Image iconSillon;
    public Image iconJarra;
    public Image iconSilla;
    public Image iconMesa;
    public Image iconVaso;

    private int objectsCollected = 0;
    private int totalObjects = 6;

    public GameObject teleportArea; // El área de teleporte que se habilita al final

    void Start()
    {
        teleportArea.SetActive(false);
    }

    public void Collect(string objectName)
    {
        switch (objectName)
        {
            case "Img_estatua": iconEstatua.color = Color.green; break;
            case "Img_sillon": iconSillon.color = Color.green; break;
            case "Img_jarra": iconJarra.color = Color.green; break;
            case "Img_silla": iconSilla.color = Color.green; break;
            case "Img_mesa": iconMesa.color = Color.green; break;
            case "Img_vaso": iconVaso.color = Color.green; break;
        }

        objectsCollected++;

        if (objectsCollected == totalObjects)
        {
            teleportArea.SetActive(true);
        }
    }
}
