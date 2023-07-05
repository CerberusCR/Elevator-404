using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuIU;
    public GameObject OptionsIU;
    public GameObject AudioUI;
    public GameObject GraphicUI;
    public GameObject PlayerWithCrosshair;
    public GameObject Crosshair;


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        OptionsIU.SetActive(false);
        AudioUI.SetActive(false);
        GraphicUI.SetActive(false);
        PlayerWithCrosshair.SetActive(true);
        Crosshair.SetActive(true);
    }

    void Pause()
    {
        Crosshair.SetActive(false);
        PlayerWithCrosshair.SetActive(false);
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Options()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 0f;
        OptionsIU.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Audio()
    {
        AudioUI.SetActive(true);
        OptionsIU.SetActive(false);
        Time.timeScale = 0f;   
        Cursor.lockState = CursorLockMode.None;
    }
 

    public void Graphics() 
    {
        GraphicUI.SetActive(true);
        AudioUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
