using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftTest : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                animator.SetBool("Open", true);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                animator.SetBool("Open", false);
            }
        }

    }
}
