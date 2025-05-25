using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils; // ✅ Importante para XROrigin

public class XRAutoFixer : MonoBehaviour
{
    void Awake()
    {
        CleanupDuplicateXRRigs();
    }

    void CleanupDuplicateXRRigs()
    {
        XROrigin[] rigs = FindObjectsOfType<XROrigin>();

        if (rigs.Length > 1)
        {
            Debug.LogWarning("🔁 [XRAutoFixer] Hay múltiples XR Rigs activos. Eliminando duplicados...");
        }

        foreach (XROrigin rig in rigs)
        {
            if (rig.gameObject.scene.name != SceneManager.GetActiveScene().name)
            {
                Debug.Log("❌ Destruyendo XR Rig antiguo de otra escena: " + rig.name);
                Destroy(rig.gameObject);
            }
        }

        if (Camera.main != null)
        {
            Debug.Log("✅ Cámara activa: " + Camera.main.name);
        }
        else
        {
            Debug.LogWarning("⚠️ No se detectó Camera.main. Verifica que tu XR Rig tenga MainCamera con tag 'MainCamera'.");
        }
    }
}
