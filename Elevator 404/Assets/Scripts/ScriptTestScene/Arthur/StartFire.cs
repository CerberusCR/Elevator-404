using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartFire : MonoBehaviour
{
    public int puzzlesComplete;
    public List<GameObject> alarmen;
    public List<GameObject> lampen;
    public Material txtr;
    public GameObject detect;
    public GameObject geluid;
    
    public void TestFire()
    {
        puzzlesComplete += 1;
        if (puzzlesComplete == 3)
        {
            
            for (int i = 0; i < 3; i++)
            {
                
                alarmen[i].GetComponent<Renderer>().material = txtr;
                
            }
            for (int i = 0; i < 3; i++)
            {

                lampen[i].GetComponent<Light>().enabled = true;
                
            }
            detect.SetActive(true);
            geluid.GetComponent<AudioSource>().mute= false;
        }
    }
}
