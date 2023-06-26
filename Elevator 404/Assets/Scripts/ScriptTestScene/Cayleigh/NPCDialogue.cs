using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    bool player_detection = false;
    public GameObject dialogue;
    public NPCAnimationController animationController; // Reference to the NPCAnimationController script

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.E))
        {
            EnableDialogue();
            Debug.Log("werkt");
        }
        else if(!player_detection)
        {
            DisableDialogue();
        }
        // Check if Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerWithCrosshair")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }

    void EnableDialogue() 
    {
        dialogue.SetActive(true);
        Invoke("DisableDialogue", 13f);
        animationController.PlayTalkAnimation(); // Trigger talk animation using the NPCAnimationController script

    }

    void DisableDialogue()
    {
        dialogue.SetActive(false);
        animationController.StopTalkAnimation(); // Stop talk animation using the NPCAnimationController script
    }
}
 

