using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeypadActivate : MonoBehaviour
{
    public TMP_Text display;
    public GameObject Keypad;
    public bool Detect = false;
    public LiftKeypad AnimationDoor;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Detect && Input.GetKeyDown(KeyCode.E))
        {
            
            Keypad.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        else if (!Detect) 
        {
            Keypad.SetActive(false);
            
        }
        // Check if Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Keypad.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Keypad.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerWithCrosshair")
        {
            Detect = true;
            //display.text = "Press E to enter the code";
            
            //player.GetComponent<PlayerController>().controllDisplay = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Detect = false;
        Cursor.lockState = CursorLockMode.Locked;
        //display.text = "";
        
        //player.GetComponent<PlayerController>().controllDisplay = true;
    }


}
