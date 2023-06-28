using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadActivate : MonoBehaviour
{
    public GameObject Keypad;
    bool Detect = false;
    public LiftKeypad AnimationDoor;

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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerWithCrosshair")
        {
            Detect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Detect = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
