using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PersistentGameManager : MonoBehaviour
{
    public static PersistentGameManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"[GameManager] Escena cargada: {scene.name}");
        CleanupDuplicateXR();
    }

    private void CleanupDuplicateXR()
    {
        var allXRManagers = FindObjectsOfType<XRInteractionManager>();
        if (allXRManagers.Length > 1)
        {
            Debug.LogWarning("⚠️ Duplicado: XRInteractionManager encontrado más de una vez. Limpiando...");
            for (int i = 1; i < allXRManagers.Length; i++)
                Destroy(allXRManagers[i].gameObject);
        }

        var allXRRigs = FindObjectsOfType<XROrigin>();
        if (allXRRigs.Length > 1)
        {
            Debug.LogWarning("⚠️ Duplicado: XROrigin encontrado más de una vez. Limpiando...");
            for (int i = 1; i < allXRRigs.Length; i++)
                Destroy(allXRRigs[i].gameObject);
        }
    }
}
