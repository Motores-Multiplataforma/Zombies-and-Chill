using UnityEngine;

public class receptorFuego : MonoBehaviour
{
    public GameObject fuego;
    private bool yaEncendido = false;

    void OnTriggerEnter(Collider other)
    {
        if (yaEncendido) return;

        if (other.gameObject.CompareTag("Flame"))
        {
            fuego.SetActive(true);
            yaEncendido = true;

            Debug.Log("🔥 Fuego encendido por contacto con 'Flame'.");

            // Notificar al sistema de victoria
            if (GameVictoryManager.Instance != null)
            {
                GameVictoryManager.Instance.MarcarHogueraEncendida();
            }
            else
            {
                Debug.LogError("❌ GameVictoryManager.Instance es null. ¿Olvidaste colocarlo en la escena?");
            }
        }
    }
}
