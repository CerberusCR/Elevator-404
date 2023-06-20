using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public AudioSource doorSound;

    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {        //Reach tool komt in contact met de deur dan word inReach true en dan is de open text active
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {       //als de reach tool exits the collinder is de inReach false en dan de open slash close text wordt gezet op false
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
    
    }
    void DoorOpens ()
    {
        Debug.Log("It opens");
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
        doorSound.Play();
    }

    void DoorCloses()
    {
        Debug.Log("It closes");
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
        doorSound.Play();
    }


}
