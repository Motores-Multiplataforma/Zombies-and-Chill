using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithID_MultipleFinal : MonoBehaviour
{
    public XRSocketInteractor socket;
    public string expectedId;
    public GameObject[] visualMeshesToEnable;

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
                // Activar todas las piezas visuales asociadas
                foreach (GameObject obj in visualMeshesToEnable)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                        Debug.Log("Activando visual: " + obj.name);
                    }
                }

                // Registrar colocación
                VictoryObjectTracker tracker = FindObjectOfType<VictoryObjectTracker>();
                if (tracker != null)
                {
                    tracker.RegistrarObjetoColocado();
                }


                // Eliminar el objeto colocado
                Destroy(placedObject);

                Debug.Log($"Objeto '{expectedId}' correctamente colocado y visual completo activado.");
            }
            else
            {
                Debug.LogWarning($"ID incorrecto: se esperaba '{expectedId}', se colocó '{pickup.objectId}'");
                socket.interactionManager.SelectExit(socket, args.interactableObject);
            }
        }
    }
}
