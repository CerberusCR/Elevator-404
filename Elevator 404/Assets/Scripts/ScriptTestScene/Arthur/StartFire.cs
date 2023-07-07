using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFire : MonoBehaviour
{
    public int puzzlesComplete;
    public GameObject alarmen;
    public Texture txtr;
    
    public void TestFire()
    {
        puzzlesComplete += 1;
        if (puzzlesComplete == 3)
        {
            print("hi");
        }
    }
}
