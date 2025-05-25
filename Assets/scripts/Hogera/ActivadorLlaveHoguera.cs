using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using System.Linq; // Necesario para .All()

public class ActivadorLlavehogera : MonoBehaviour
{
    [Header("Configuración de la hogera")]
    [Tooltip("Referencia al GameObject 'hogera' que contiene los XR Socket Interactors.")]
    public GameObject hogeraParent;

    [Tooltip("La llave que aparecerá una vez que todos los troncos estén en su lugar.")]
    public GameObject LlaveAlbert;

    private List<XRSocketInteractor> socketshogera = new List<XRSocketInteractor>();
    private bool llaveActivada = false;

    void Start()
    {
        // Aseguramos que la llave esté inicialmente desactivada
        if (LlaveAlbert != null)
        {
            LlaveAlbert.SetActive(false);
        }
        else
        {
            Debug.LogError("ActivadorLlavehogera: ¡La referencia a 'Llave Albert' no está asignada! Asígnala en el Inspector.");
            enabled = false; // Desactiva el script si no hay llave para evitar errores.
            return;
        }

        // Obtener todos los XRSocketInteractor dentro del GameObject 'hogera'
        if (hogeraParent != null)
        {
            socketshogera = hogeraParent.GetComponentsInChildren<XRSocketInteractor>().ToList();

            if (socketshogera.Count == 0)
            {
                Debug.LogWarning("ActivadorLlavehogera: No se encontraron XRSocketInteractor dentro del GameObject 'hogera'. Asegúrate de que los 'LugarTroncoquemar' los tengan.");
            }

            // Suscribirse a los eventos de selección de cada socket
            foreach (var socket in socketshogera)
            {
                socket.selectEntered.AddListener(OnSocketSelectEntered);
                socket.selectExited.AddListener(OnSocketSelectExited); // En caso de que se saque un tronco
            }
        }
        else
        {
            Debug.LogError("ActivadorLlavehogera: ¡La referencia a 'hogera Parent' no está asignada! Asígnala en el Inspector.");
            enabled = false;
        }
    }

    void OnSocketSelectEntered(SelectEnterEventArgs args)
    {
        // Solo necesitamos verificar una vez que algo se ha insertado.
        CheckAllSocketsFilled();
    }

    void OnSocketSelectExited(SelectExitEventArgs args)
    {
        // Si un tronco se quita, la llave debería desaparecer si ya estaba activa.
        if (llaveActivada)
        {
            CheckAllSocketsFilled();
        }
    }

    void CheckAllSocketsFilled()
    {
        if (llaveActivada) return; // Si la llave ya está activa, no hacemos más comprobaciones.

        // Comprueba si todos los sockets tienen un objeto interactuable seleccionado.
        // Usamos LINQ para una comprobación concisa y eficiente.
bool allSocketsOccupied = socketshogera.All(socket => socket.hasSelection);

        if (allSocketsOccupied)
        {
            if (LlaveAlbert != null)
            {
                LlaveAlbert.SetActive(true);
                llaveActivada = true;
                Debug.Log("¡Todos los troncos están en su lugar! La Llave Albert ha aparecido.");
                // Opcional: Podrías desuscribirte de los eventos para ahorrar rendimiento si no necesitas más comprobaciones.
                // foreach (var socket in socketshogera)
                // {
                //     socket.selectEntered.RemoveListener(OnSocketSelectEntered);
                //     socket.selectExited.RemoveListener(OnSocketSelectExited);
                // }
            }
        }
        else
        {
            // Si algún tronco fue quitado después de que la llave apareciera
            if (llaveActivada && LlaveAlbert != null)
            {
                LlaveAlbert.SetActive(false);
                llaveActivada = false;
                Debug.Log("Algunos troncos fueron quitados. La Llave Albert ha desaparecido.");
            }
        }
    }

    void OnDestroy()
    {
        // Limpiar los listeners al destruir el script para evitar memory leaks
        foreach (var socket in socketshogera)
        {
            if (socket != null) // Asegurarse de que el socket no sea nulo antes de quitar el listener
            {
                socket.selectEntered.RemoveListener(OnSocketSelectEntered);
                socket.selectExited.RemoveListener(OnSocketSelectExited);
            }
        }
    }
}