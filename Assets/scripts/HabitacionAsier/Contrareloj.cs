using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Contrareloj : MonoBehaviour
{
    public static Contrareloj Instance;

    public GameObject reloj;
    public float tiempoRestante = 900f;  // 15 minutos en segundos
    private bool tiempoActivo = true;
    private TextMeshProUGUI textoReloj;  // El componente de texto
    
    private float timer = 0f;
    private bool parpadeoActivo = false;
    //private bool activated = false;



    //Prueba musica
    //private bool haCambiadoMusica = false;

    // Variable para controlar el cambio de música
    private int pistaActual = 0;


    void Awake()
    {
        reloj = GameObject.Find("contraReloj");
        if (reloj != null)
        {
            textoReloj = reloj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'contraReloj'.");
        }

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Al inicio, reproducimos la primera música
        AudioManager.Instance.SonarMusica(AudioManager.Instance.banda[0]);
    }

   //
   //------------Añadido para mantener script al pasar de escenas

void OnEnable()
{
    SceneManager.sceneLoaded += OnSceneLoaded;
}

void OnDisable()
{
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    reloj = GameObject.Find("contraReloj");

    if (reloj != null)
    {
        textoReloj = reloj.GetComponent<TextMeshProUGUI>();
        ActualizarReloj(); // Actualiza el reloj visualmente en la nueva escena
    }
    else
    {
        textoReloj = null; // Para evitar errores si no hay reloj en esta escena
        Debug.LogWarning("No se encontró el objeto 'contraReloj' en la escena " + scene.name);
    }
}


    //----------------------------------------------------------------------

    // Update is called once per frame

    
 void Update()
        {
         if (tiempoActivo && tiempoRestante > 0)
            {
                //Esta línea resta segundos
                tiempoRestante -= Time.deltaTime;
                ActualizarReloj();

                // Activar parpadeo al llegar al último minuto
                if (tiempoRestante <= 60 && !parpadeoActivo)
                {
                    parpadeoActivo = true;
                }
            }
            else if (tiempoRestante <= 0 && tiempoActivo)
{
        tiempoRestante = 0;
        tiempoActivo = false;
        ActualizarReloj();

        Debug.Log("¡Tiempo terminado!");
    
        // Cambiar de escena al llegar a cero
        SceneManager.LoadScene("GameOverPerdio");
}

             // Efecto de parpadeo cuando quedan menos de 60 segundos
            if (parpadeoActivo)
            {
                timer += Time.deltaTime;
                if (timer >= 0.5f && timer < 1.5f)
                {
                    textoReloj.enabled = false;
                }
                else if (timer >= 1.5f)
                {
                    textoReloj.enabled = true;
                    timer = 0f;
                }
            }

            //Metodo antiguo de cambio de audio
        /*  if (tiempoRestante > 0)
          {
              //tiempoRestante -= Time.deltaTime;

              // Cuando queden menos de 6 minutos, cambia la música si no lo ha hecho ya
              if (tiempoRestante <= 890 && !haCambiadoMusica)
              {
                  AudioManager.Instance.CrossfadeMusica(AudioManager.Instance.banda[1], 2f); // duración de 2 segundos
                  haCambiadoMusica = true;
              }

              if (tiempoRestante <= 880 && !haCambiadoMusica)
              {
                  AudioManager.Instance.CrossfadeMusica(AudioManager.Instance.banda[2], 2f); // duración de 2 segundos
                  haCambiadoMusica = true;
              }

              UpdateTimerDisplay(tiempoRestante);
          }
          else
          {
              tiempoRestante = 0;
              UpdateTimerDisplay(tiempoRestante);
          }*/

        // Cambiar la música dependiendo del tiempo restante
        if (tiempoRestante <= 240 && pistaActual == 0)
        {
            CambiarMusica(1);  // Cambiar a la siguiente música
        }

        //Estas líneas sirven para poer cambiar de pista de audio. Sólo hay que marcar el segundo en el que quieres que cambie
        /*else if (tiempoRestante <= 880 && pistaActual == 1)
        {
            CambiarMusica(2);
        }
        else if (tiempoRestante <= 870 && pistaActual == 2)
        {
            CambiarMusica(3);
        }*/

    }


   


    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        textoReloj.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    void ActualizarReloj()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoReloj.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    // Método para cambiar la música
    void CambiarMusica(int nuevoIndice)
    {
        if (nuevoIndice >= 0 && nuevoIndice < AudioManager.Instance.banda.Length && nuevoIndice != pistaActual)
        {
            pistaActual = nuevoIndice;
            AudioManager.Instance.CrossfadeMusica(AudioManager.Instance.banda[pistaActual], 2f); // Duración del crossfade
        }
    }
}
