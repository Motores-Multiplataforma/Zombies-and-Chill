using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbDesactivarColliderConLlaveAlb : MonoBehaviour
{
    public Collider colliderADesactivar; // Asigna el collider desde el inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LlaveAlbert"))
        {
            Debug.Log("Llave detectada. Desactivando collider...");
            if (colliderADesactivar != null)
            {
                colliderADesactivar.enabled = false;
            }
            else
            {
                Debug.LogWarning("No se asign� ning�n collider para desactivar.");
            }
        }
    }
}

