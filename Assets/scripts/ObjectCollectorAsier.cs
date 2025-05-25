using UnityEngine;
using UnityEngine.UI;

public class ObjectCollectorAsier : MonoBehaviour
{
    public Image[] icons; // Asigna 6 íconos en el orden correcto
    public string[] ids = { "alfombra", "cojin", "cuchillo", "lata", "mechero", "ajedrez" };

    private int collected = 0;
    public GameObject teleportZone; // Asigna el área de teletransporte en el Inspector

    void Start()
    {
        teleportZone.SetActive(false);
    }

    public void Collect(string id)
    {
        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i] == id)
            {
                icons[i].color = Color.green;
                break;
            }
        }

        collected++;
        if (collected >= ids.Length)
        {
            teleportZone.SetActive(true);
        }
    }
}

