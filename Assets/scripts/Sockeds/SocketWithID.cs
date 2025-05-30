using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithID : MonoBehaviour
{
    public XRSocketInteractor socket;
    public string expectedId;
    public GameObject visualMeshToEnable;

    private void OnEnable()
    {
        socket.selectEntered.AddListener(CheckObject);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(CheckObject);
    }

    private void CheckObject(SelectEnterEventArgs args)
    {
        GameObject placedObject = args.interactableObject.transform.gameObject;
        var pickup = placedObject.GetComponent<PickupObjectAsier>();

        if (pickup != null)
        {
            if (pickup.objectId == expectedId)
            {
                // Activar visual
                if (visualMeshToEnable != null)
                    visualMeshToEnable.SetActive(true);

                // Registrar la colocación del objeto
                ObjectPlacementManager placementManager = FindObjectOfType<ObjectPlacementManager>();
                if (placementManager != null)
                {
                    placementManager.RegisterPlacement();
                }

                // Eliminar objeto
                Destroy(placedObject);
            }
            else
            {
                Debug.LogWarning($"ID incorrecto. Se esperaba: {expectedId}, pero se colocó: {pickup.objectId}");
                socket.interactionManager.SelectExit(socket, args.interactableObject);
            }
        }
    }
}
