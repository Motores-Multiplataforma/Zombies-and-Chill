using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //Para llamar al script desde cualquier lado
    public static AudioManager Instance;

  
    public AudioClip[] fx;
    public AudioSource _audioSource;

    public GameObject musicObj;
    public GameObject musicObj2;
    public GameObject musicObj3;
    //public GameObject musicObj4;
    //public GameObject musicObj5;
    

    public AudioSource audioMusic;
    public AudioSource audioMusic02;
    public AudioSource audioMusic03;
    //public AudioSource audioMusic04;
    //public AudioSource audioMusic05;



    public AudioClip[] banda;



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
        audioMusic03 = musicObj3.GetComponent<AudioSource>();
        //audioMusic04 = musicObj4.GetComponent<AudioSource>();
        //audioMusic05 = musicObj5.GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
       
        audioMusic.loop = true;
        audioMusic.volume = 1f;
     
   
        _audioSource.loop = true;
        _audioSource.volume = 1f;


    }

    // Update is called once per frame
    void Update()
    {
        //Activar musica
        if (Input.GetKeyDown(KeyCode.P))
        {
 
            audioMusic.Play();
            audioMusic.loop = true;
            //Debug.Log("Esta sonando "+ bandaSonora);
        }
        //Parar musica
        if (Input.GetKeyDown(KeyCode.O))
        {
     
            audioMusic.Pause();
            audioMusic.loop = false;
        }
        
    }

 

    //método para hacer sonar clips de audio
    public void SonarCLipUnaVez(AudioClip ac)
    {
        _audioSource.PlayOneShot(ac);
    }

    public void SonarMusica(AudioClip escena)
    {

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
