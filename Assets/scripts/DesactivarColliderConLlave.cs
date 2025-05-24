using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarColliderConLlave : MonoBehaviour
{
    public Collider colliderADesactivar; // Asigna el collider desde el inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Llave"))
        {
            Debug.Log("Llave detectada. Desactivando collider...");
            if (colliderADesactivar != null)
            {
                colliderADesactivar.enabled = false;
            }
            else
            {
                Debug.LogWarning("No se asignó ningún collider para desactivar.");
            }
        }
    }
}

