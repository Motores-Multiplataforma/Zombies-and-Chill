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
    public float tiempoRestante = 420f;  // 7 minutos en segundos
    private bool tiempoActivo = true;
    private TextMeshProUGUI textoReloj;  // El componente de texto

    private float timer = 0f;
    private bool parpadeoActivo = false;
    //private bool activated = false;

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


        }
    

    /*   Esta parte es similar a a de arriba, pero ChatGpt cambió algunas cosas. No sé si a mejor o a peor
     *   Pero, Las dos funcionan

    void Update()
    {
        if (tiempoActivo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;

            if (textoReloj != null)
                ActualizarReloj();

            if (tiempoRestante <= 60 && !parpadeoActivo)
            {
                parpadeoActivo = true;
            }
        }
        else if (tiempoRestante <= 0 && tiempoActivo)
        {
            tiempoRestante = 0;
            tiempoActivo = false;

            if (textoReloj != null)
                ActualizarReloj();

            Debug.Log("¡Tiempo terminado!");
        }

        // Parpadeo
        if (parpadeoActivo && textoReloj != null)
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
    }
    */


    void ActualizarReloj()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoReloj.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
