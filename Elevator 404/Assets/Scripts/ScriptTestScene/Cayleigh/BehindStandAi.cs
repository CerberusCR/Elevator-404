using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindStandAi : MonoBehaviour
{
    public Animator RedDogAi;
    // Start is called before the first frame update
    void Start()
    {
        RedDogAi.SetBool("IsTalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
