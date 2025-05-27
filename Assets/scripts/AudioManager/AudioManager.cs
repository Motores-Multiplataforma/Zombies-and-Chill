using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //Para llamar al script desde cualquier lado
    public static AudioManager Instance;

    //Añade sonidos
    //public AudioClip bandaSonora;

    //public AudioClip bandaSonora02;
    //public AudioClip fxButton;
    public AudioClip[] fx;
    public AudioSource _audioSource;

    public GameObject musicObj;
    public GameObject musicObj2;
    public AudioSource audioMusic;
    public AudioSource audioMusic02;
    //public static AudioSource audioMusic02;

    public AudioClip[] banda;


    //Scene scene;
    //LoadSceneMode mode;

    //Patrón Singletón.
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
        audioMusic = musicObj.GetComponent<AudioSource>();
        audioMusic02 = musicObj2.GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
        


        //Aqui se carga la musica 
        //audioMusic = musicObj.GetComponent<AudioSource>();
        //audioMusic.clip = bandaSonora;
        // audioMusic.clip = banda[0];
        audioMusic.loop = true;
        audioMusic.volume = 1f;
     
        //_audioSource.Play();
        _audioSource.loop = true;
        _audioSource.volume = 1f;


        //audioMusic02 = musicObj2.GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        //Activar musica
        if (Input.GetKeyDown(KeyCode.P))
        {
            //_audioSource.Play();
            //_audioSource.loop = true;
            audioMusic.Play();
            audioMusic.loop = true;
            //Debug.Log("Esta sonando "+ bandaSonora);
        }
        //Parar musica
        if (Input.GetKeyDown(KeyCode.O))
        {
            //_audioSource.Pause();
            //_audioSource.loop = false;
            audioMusic.Pause();
            audioMusic.loop = false;
        }
        /*
                scene = SceneManager.GetActiveScene();

                if(scene.name == "1Menu"){
                   /* audioMusic.Stop();
                audioMusic.clip = banda[1];
                audioMusic.Play();
                audioMusic.loop = true;
                audioMusic.volume = 1f;
                //audioMusic.Pause();
                audioMusic02.clip = banda[1];
                audioMusic02.Play();


                    /*
                    audioMusic02.clip = bandaSonora02;
                    audioMusic02.Play();
                    audioMusic02.loop = true;
                    audioMusic02.volume = 1f;
                }
                if(scene.name == "2NivelUno"){
                    //audioMusic.Stop();
                    audioMusic.Pause();
                    audioMusic.clip = banda[0];
                    //audioMusic.Play();

                }

                //CambioMusica();*/
    }

    /* public void CambioMusica(){
         Debug.Log("OnSceneLoaded: " + scene.name);
         if(scene.name == "1Menu"){
             audioMusic = musicObj.GetComponent<AudioSource>();
             audioMusic.clip = bandaSonora02;
             audioMusic.Stop();
             audioMusic.loop = true;
             audioMusic.volume = 1f;
         }


     }*/
    /*
        void OnSceneLoaded(Scene scene, LoadSceneMode mode){
            if(){
            audioMusic = musicObj.GetComponent<AudioSource>();
            audioMusic.clip = bandaSonora02;
            audioMusic.Play();
            audioMusic.loop = true;
            audioMusic.volume = 1f;
            }

            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log("OnSceneLoadedmmmmmmm: " + mode);
        }
    */

    //método para hacer sonar clips de audio
    public void SonarCLipUnaVez(AudioClip ac)
    {
        _audioSource.PlayOneShot(ac);
    }

    public void SonarMusica(AudioClip escena)
    {
        //_audioSource.clip = escena;
        //_audioSource.Play();

        audioMusic.clip = escena;
        audioMusic.Play();
     
    }

    public void CambiarMusica(AudioClip nuevaMusica)
{
    if (audioMusic.clip != nuevaMusica)
    {
        audioMusic.Stop();
        audioMusic.clip = nuevaMusica;
        audioMusic.Play();
    }
}


public void CrossfadeMusica(AudioClip nuevaMusica, float duracion = 3f)
{
    StartCoroutine(FadeMusic(nuevaMusica, duracion));
}

private IEnumerator FadeMusic(AudioClip nuevaMusica, float duracion)
{
    AudioSource actual = audioMusic.isPlaying ? audioMusic : audioMusic02;
    AudioSource nuevo = (actual == audioMusic) ? audioMusic02 : audioMusic;

    nuevo.clip = nuevaMusica;
    nuevo.volume = 0f;
    nuevo.Play();

    float tiempo = 0f;

    while (tiempo < duracion)
    {
        tiempo += Time.deltaTime;
        float t = tiempo / duracion;

        actual.volume = Mathf.Lerp(1f, 0f, t);
        nuevo.volume = Mathf.Lerp(0f, 1f, t);

        yield return null;
    }

    actual.Stop();
    actual.volume = 1f;
    // al final, aseguramos que solo quede uno sonando
}
}
