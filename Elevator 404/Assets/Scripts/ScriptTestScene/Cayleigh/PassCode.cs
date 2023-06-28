using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PassCode : MonoBehaviour
{
    string code = "1234";
    string Nr = null;
    int NrIndex = 0;
    string aplha;
    public Text UiText = null;

    public LiftKeypad AnimationDoor;

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
            
        }
    }
    public void Delete() 
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}

