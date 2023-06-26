using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    public Animator npcAnimator; // Reference to the NPC's Animator component

    public void PlayTalkAnimation()
    {
        npcAnimator.SetBool("IsTalking", true);
    }

    public void StopTalkAnimation()
    {
        npcAnimator.SetBool("IsTalking", false);
    }

    public void PlayIdleAnimation()
    {
        npcAnimator.SetBool("IsIdle", true);
    }

    public void StopIdleAnimation()
    {
        npcAnimator.SetBool("IsIdle", false);
    }
}
