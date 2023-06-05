using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Liftknop : MonoBehaviour
{
    public int sceneToLoad;
    public void Interact()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
