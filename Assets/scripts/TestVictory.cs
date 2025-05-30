using UnityEngine;
using UnityEngine.SceneManagement;

public class TestVictory : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (Contrareloj.Instance != null)
            {
                Contrareloj.Instance.GanarJuego();
            }
            else
            {
                Debug.LogError("Contrareloj.Instance no está presente.");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Contrareloj.Instance != null)
            {
                Debug.Log("🔻 Forzando derrota...");
                SceneManager.LoadScene(Contrareloj.Instance.nombreEscenaDerrota);
            }
            else
            {
                Debug.LogError(" Contrareloj.Instance no está presente para forzar derrota.");
            }
        }
    }
}
