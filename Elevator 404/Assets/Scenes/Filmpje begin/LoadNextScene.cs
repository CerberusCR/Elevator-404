using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public int sceneToLoad;
    public void GotoNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
