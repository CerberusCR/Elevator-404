using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    bool player_detection = false;
    public GameObject dialogue;
    public NPCAnimationController animationController; // Reference to the NPCAnimationController script
    public AudioSource audioSource;  // Reference to the audio source

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.E))
        {
            EnableDialogue();
            Debug.Log("werkt");
        }
        else if (!player_detection)
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
        animationController.StopIdleAnimation(); // Stop idle animation when the player exits the NPC's trigger area
        DisableDialogue(); // Stop the dialogue and audio when the player exits the NPC's trigger area
    }

    void EnableDialogue()
    {
        dialogue.SetActive(true);
        audioSource.Play(); // Start playing the audio
        Invoke("DisableDialogue", 13f);
        animationController.PlayTalkAnimation(); // Trigger talk animation using the NPCAnimationController script
        animationController.StopIdleAnimation(); // Stop idle animation when the player exits the NPC's trigger area
    }

    void DisableDialogue()
    {
        dialogue.SetActive(false);
        audioSource.Stop(); // Stop playing the audio
        animationController.StopTalkAnimation(); // Stop talk animation using the NPCAnimationController script
        animationController.PlayIdleAnimation(); // Trigger idle animation when the player enters the NPC's trigger area
    }
}


