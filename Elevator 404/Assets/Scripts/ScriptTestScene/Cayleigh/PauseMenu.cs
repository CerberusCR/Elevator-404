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
    }

    void Pause()
    {
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

    public void BackOptions()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
