using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PassCode : MonoBehaviour
{
    string code = "2513";
    string Nr = null;
    int NrIndex = 0;
    string aplha;
    public Text UiText = null;
    public GameObject liftBlock;

    public LiftKeypad animationDoor;

    public GameObject Keypad;

    private void Start()
    {

    }
    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
        
    }
    public void Enter()
    {
        if (Nr == code)
        {
            Debug.Log("It's working");
            animationDoor.PlayOpen();
            liftBlock.SetActive(false);
            Keypad.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;

        }
    }
    public void Delete() 
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}

