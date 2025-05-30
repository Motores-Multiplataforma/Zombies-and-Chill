using UnityEngine;

public class GameVictoryManager : MonoBehaviour
{
    public static GameVictoryManager Instance;

    private bool objetosColocados = false;
    private bool hogueraEncendida = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Llama esto cuando TODOS los objetos estén colocados en sus sockets
    public void MarcarObjetosColocados()
    {
        objetosColocados = true;
        Debug.Log("Objetos colocados marcados.");
        VerificarVictoria();
    }

    public void MarcarHogueraEncendida()
    {
        hogueraEncendida = true;
        Debug.Log("Hoguera encendida marcada.");
        VerificarVictoria();
    }


    private void VerificarVictoria()
    {
        Debug.Log($"Verificando victoria... ObjetosColocados: {objetosColocados}, HogueraEncendida: {hogueraEncendida}");

        if (objetosColocados && hogueraEncendida)
        {
            Debug.Log("¡Victoria! Objetos colocados y hoguera encendida.");

            if (Contrareloj.Instance != null)
            {
                Debug.Log("Contrareloj.Instance está presente. Cambiando escena...");
                Contrareloj.Instance.GanarJuego();
            }
            else
            {
                Debug.LogError("Contrareloj.Instance es null.");
            }
        }
    }

}
