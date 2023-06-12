using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour

{
    public GameObject credits;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject audioOptions;
    public GameObject graphicsOptions;



    public void Play()
    {
        //print("hi");
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void BackCredits()
    {
        credits.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void Options()
    {
        options.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }
    public void BackOptions()
    {
        options.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
    public void AudioOptions()
    {
        options.gameObject.SetActive(false);
        audioOptions.gameObject.SetActive(true);
    }

    public void GraphicsOptions()
    {
        options.gameObject.SetActive(false);
        graphicsOptions.gameObject.SetActive(true);
    }
    public void BackToOptions()
    {
        options.gameObject.SetActive(true);
        audioOptions.gameObject.SetActive(false);
        graphicsOptions.gameObject.SetActive(false);
    }
}
