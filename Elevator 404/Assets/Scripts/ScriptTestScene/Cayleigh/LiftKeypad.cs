using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftKeypad : MonoBehaviour
{
    public Animator npcAnimator; // Reference to the NPC's Animator component

    public void PlayOpen()
    {
        npcAnimator.SetBool("IsOpen", true);
    }

    public void PlayClose()
    {
        npcAnimator.SetBool("IsClose", true);
    }
}
