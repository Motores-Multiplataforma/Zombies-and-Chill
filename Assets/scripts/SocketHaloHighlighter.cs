using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketHaloHighlighter : MonoBehaviour
{
    [Header("Configuración")]
    public string expectedId;          // ID del objeto que debe coincidir
    public GameObject haloVisual;      // GameObject que se activa como guía visual

    private XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();

        if (haloVisual != null)
            haloVisual.SetActive(false);

        // Detectar cuando se suelta (hover)
        socket.hoverEntered.AddListener(OnHoverEnter);
        socket.hoverExited.AddListener(OnHoverExit);

        // Detectar cuando se agarra con el rayo (select)
        socket.selectEntered.AddListener(OnSelectEnter);
        socket.selectExited.AddListener(OnSelectExit);
    }
   


    void OnHoverEnter(HoverEnterEventArgs args)
    {
        ShowHaloIfMatches(args.interactableObject.transform.gameObject);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        Debug.Log("selectEntered activado con: " + args.interactableObject.transform.name);
        ShowHaloIfMatches(args.interactableObject.transform.gameObject);
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        if (haloVisual != null)
            haloVisual.SetActive(false);
    }

    void OnSelectExit(SelectExitEventArgs args)
    {
        if (haloVisual != null)
            haloVisual.SetActive(false);
    }

    private void ShowHaloIfMatches(GameObject obj)
    {
        var pickup = obj.GetComponent<PickupObjectAsier>();
        if (pickup != null && pickup.objectId == expectedId)
        {
            if (haloVisual != null)
                haloVisual.SetActive(true);
        }
    }
}
