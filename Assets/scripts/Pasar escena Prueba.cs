using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarescenaPrueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cambiar de escena con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cambioEscena();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            cambioEscena02();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            cambioEscena03();
        }

    }

    public void cambioEscena()
    {
        SceneManager.LoadScene("EscenaHabAlberto");
    }

    public void cambioEscena02()
    {
        SceneManager.LoadScene("EscenaHabAsier");
    }

    public void cambioEscena03()
    {
        SceneManager.LoadScene("EscenaInicio");
    }
}
