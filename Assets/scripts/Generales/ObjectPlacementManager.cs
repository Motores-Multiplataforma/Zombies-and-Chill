using UnityEngine;

public class ObjectPlacementManager : MonoBehaviour
{
    public int totalObjects = 5;
    private int placedObjects = 0;

    public GameObject teleportToActivate;
    public GameObject keyToActivate; // 🗝️ NUEVO: la llave

    public void RegisterPlacement()
    {
        placedObjects++;

        Debug.Log("Objeto colocado. Total: " + placedObjects);

        if (placedObjects >= totalObjects)
        {
            Debug.Log("Todos los objetos colocados. Activando teleport y llave.");

            if (teleportToActivate != null)
                teleportToActivate.SetActive(true);

            if (keyToActivate != null)
                keyToActivate.SetActive(true);
        }
    }
}
