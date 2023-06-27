using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcToNpc : MonoBehaviour
{
    public Animator npcToNpc;
    private bool isIdle = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimationLoop());
    }

    // Coroutine to handle the animation loop
    IEnumerator AnimationLoop()
    {
        while (true)
        {
            // Wait for 10 seconds
            yield return new WaitForSeconds(6);

            // Change the boolean parameters
            isIdle = false;
            npcToNpc.SetBool("IsIdle", isIdle);
            npcToNpc.SetBool("IsTalking", true);

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Reset the boolean parameters
            isIdle = true;
            npcToNpc.SetBool("IsIdle", isIdle);
            npcToNpc.SetBool("IsTalking", false);
        }
    }
}
