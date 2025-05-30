using UnityEngine;

public class VictoryObjectTracker : MonoBehaviour
{
    public int totalObjetosNecesarios = 5;
    private int objetosColocados = 0;

    public void RegistrarObjetoColocado()
    {
        objetosColocados++;
        Debug.Log($"Objeto para victoria colocado. Total: {objetosColocados}/{totalObjetosNecesarios}");

        if (objetosColocados >= totalObjetosNecesarios)
        {
            Debug.Log(" Todos los objetos necesarios colocados.");

            // 🔥 Notificar a GameVictoryManager
            if (GameVictoryManager.Instance != null)
            {
                GameVictoryManager.Instance.MarcarObjetosColocados();
            }
            else
            {
                Debug.LogError("GameVictoryManager.Instance no está presente en la escena.");
            }
        }
    }
}
