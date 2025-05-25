using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    private static AmbientSoundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // <- Aquí se refiere a este GameObject (AmbientSound)
        }
        else
        {
            Destroy(gameObject); // Evita duplicados si vuelve a cargarse
        }
    }
}
