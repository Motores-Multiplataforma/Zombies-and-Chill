using UnityEngine;

public class PickupZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var pickup = other.GetComponent<PickupObjectAsier>();
        if (pickup != null)
        {
            pickup.Collect(); // Llama a la función del objeto
        }
    }
}
