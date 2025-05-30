using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RespawnIfFall : MonoBehaviour
{
    public Transform respawnPoint;
    public AudioClip returnSound;
    public float fallThresholdY = -10f;

    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;
    private bool isHeld;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        if (respawnPoint == null)
            respawnPoint = transform;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
    }

    void Update()
    {
        if (!isHeld && transform.position.y < fallThresholdY)
        {
            Debug.Log($"Objeto cayó por debajo del umbral Y: {transform.position.y}");
            Respawn();
        }
    }

    void Respawn()
    {
        Debug.Log("Reposicionando objeto al punto de respawn.");
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        if (audioSource != null && returnSound != null)
            audioSource.PlayOneShot(returnSound);
    }
}
