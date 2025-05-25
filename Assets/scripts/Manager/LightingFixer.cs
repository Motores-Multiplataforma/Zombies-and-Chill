using UnityEngine;

public class LightingFixer : MonoBehaviour
{
    private bool fixedOnce = false;

    void OnEnable()
    {
        // Aplica también aquí por seguridad
        FixReflectionSettings();
    }

    void Start()
    {
        FixReflectionSettings();
    }

    void LateUpdate()
    {
        // Solo lo hacemos una vez en LateUpdate para asegurar que nadie lo sobrescribió
        if (!fixedOnce)
        {
            FixReflectionSettings();
            fixedOnce = true;
        }
    }

    void FixReflectionSettings()
    {
        RenderSettings.defaultReflectionMode = UnityEngine.Rendering.DefaultReflectionMode.Skybox;
        RenderSettings.customReflection = null;

        Debug.Log("✅ LightingFixer: Reflection configurada correctamente en Skybox.");
    }
}
