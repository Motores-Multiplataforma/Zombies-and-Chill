using UnityEngine;
using TMPro;
using System.Collections;

public class TextoTemporizador : MonoBehaviour
{
    public TextMeshProUGUI recordarTarea; // Asigna desde el Inspector

    void Start()
    {
        StartCoroutine(DesaparecerTexto());
    }

    IEnumerator DesaparecerTexto()
    {
        recordarTarea.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        recordarTarea.gameObject.SetActive(false);
    }
}
