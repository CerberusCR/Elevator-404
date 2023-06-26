using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    public Animator npcAnimator; // Reference to the NPC's Animator component

    public void PlayTalkAnimation()
    {
        npcAnimator.SetBool("IsTalking", true); // Trigger the "IsTalking" parameter in the NPC's animator
    }

    public void StopTalkAnimation()
    {
        npcAnimator.SetBool("IsTalking", false); // Disable the "IsTalking" parameter in the NPC's animator
    }
}
