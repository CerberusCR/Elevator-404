using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftKeypad : MonoBehaviour
{
    public Animator animator; // Reference to the NPC's Animator component

    public void PlayOpen()
    {
        animator.SetBool("IsOpen", true);
    }

    public void NotOpen()
    {
        animator.SetBool("IsOpen", false);
    }

    public void PlayClose()
    {
        animator.SetBool("IsCLose", true);
    }

    public void NotClose()
    {
        animator.SetBool("IsClose", false);
    }

}
