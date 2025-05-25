using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupObjectAsier : MonoBehaviour
{
    public string objectId; // Ej: "cojin", "cuchillo", etc.

    public void Collect()
    {
        FindObjectOfType<ObjectCollectorAsier>()?.Collect(objectId);
        Destroy(gameObject);
    }
}
