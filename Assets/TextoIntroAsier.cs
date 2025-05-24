using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TextoIntroAsier : MonoBehaviour
{ 
    public GameObject texto;
    public float timer;
    public float tiempoAparicion;
    public static bool activated = false;
    private bool tiempoAparicionFinalizado = false;

    public InputActionProperty rightTriggerAction;

    void Awake(){
        texto = GameObject.Find("Texto");
        texto.GetComponent<TextMeshProUGUI>().enabled = false; // Ocultamos el texto al principio
    }

    void Update()
    {
        // Asigna el texto siempre (o podrías mover esto a Start si no cambia)
        texto.GetComponent<TextMeshProUGUI>().text = "Pulsa trigger derecho";

        if (!tiempoAparicionFinalizado)
        {
            tiempoAparicion += Time.deltaTime; // Incrementa solo cuando no está finalizado
        }
        timer += Time.deltaTime;

        // Parpadeo solo si el tiempo ya pasó y no está "desactivado"
        if (tiempoAparicion >= 6 && !activated)
        {
            if (timer >= 0.5f)
            {
                // Cambia visibilidad del texto (solo el componente)
                TextMeshProUGUI tmp = texto.GetComponent<TextMeshProUGUI>();
                tmp.enabled = !tmp.enabled;
                timer = 0;
            }
        }

        // Detener el contador a los 3 segundos
        if (!tiempoAparicionFinalizado && tiempoAparicion > 8)
        {
            tiempoAparicion = 8; // por si acaso, lo dejas en 3 exacto
            tiempoAparicionFinalizado = true;
            Debug.Log("¡Contador detenido!");
        }

        // Cambiar de escena con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cambioEscena();
        }

        if (rightTriggerAction.action.WasPressedThisFrame())
        {
            cambioEscena();
        }
    }

    public void cambioEscena(){
        SceneManager.LoadScene("EscenaHabAsier");
    }
}
