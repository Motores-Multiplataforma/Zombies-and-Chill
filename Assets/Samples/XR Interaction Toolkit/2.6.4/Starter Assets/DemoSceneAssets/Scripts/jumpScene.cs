using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpScene : MonoBehaviour
{
    public string sceneName;

    public void doJump()
    {
        SceneManager.LoadScene(sceneName);
    }
}

