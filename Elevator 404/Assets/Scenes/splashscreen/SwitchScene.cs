using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public float time;
    

    public void Start()
    {
        StartCoroutine(SwitchScenes());
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }
    public IEnumerator SwitchScenes()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }
}
