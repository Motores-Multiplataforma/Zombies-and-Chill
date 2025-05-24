using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupObject : MonoBehaviour
{
    public string objectId; // Ejemplo: "Img_jarra", "Img_mesa", etc.

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!string.IsNullOrEmpty(objectId))
        {
            FindObjectOfType<ObjectCollector>().Collect(objectId);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("objectId no asignado en " + gameObject.name);
        }
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }
}
