using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class SceneChanger : MonoBehaviour
{
    public string home; // El nombre de la escena que deseas cargar

    void Start()
    {
        // Llama a la función para cambiar de escena después de 4 segundos
        Invoke("ChangeScene", 10f);
    }

    void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(home);
    }
}
