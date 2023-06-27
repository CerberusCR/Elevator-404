using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGdogs : MonoBehaviour
{
    public Animator npcToNpc;

    // Start is called before the first frame update
    void Start()
    {
        npcToNpc.SetBool("IsIdle", true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
