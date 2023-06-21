using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Liftknop : MonoBehaviour
{
    public int sceneToLoad;
    public GameObject player;

    public void Start()
    {
        StartCoroutine(player.GetComponentInChildren<Canvas>().GetComponent<Fadeout2>().FadeOut());
    }
    public void Interact()
    {
        StartCoroutine(player.GetComponentInChildren<Canvas>().GetComponent<Fadeout2>().FadeIn());
        StartCoroutine(SceneSwitch());
        
    }
    public IEnumerator SceneSwitch()
    {
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }
}

