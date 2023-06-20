using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Fadeout : MonoBehaviour
{
    /*
    public GameObject postprocessingGlobal;
    public ChannelMixer mixer;
    public float fadeAmount;

    public void Start()
    {
        mixer = (ChannelMixer)postprocessingGlobal.GetComponent<Volume>().profile.components[0];
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(FadeIn());
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeOut());
        }
    }
    public IEnumerator FadeIn()
    {
        //fadeAmount -= fadeSpeed * Time.deltaTime;
        ClampedFloatParameter cP = new ClampedFloatParameter(0, -200, 200, true);
        mixer.blueOutBlueIn = cP;
        mixer.blueOutGreenIn = cP;
        mixer.blueOutRedIn = cP;
        mixer.greenOutBlueIn = cP;
        mixer.greenOutGreenIn = cP;
        mixer.greenOutRedIn = cP;
        mixer.redOutBlueIn = cP;
        mixer.redOutGreenIn = cP;
        mixer.redOutRedIn = cP;
        
        mixer.SetDirty();
        
        yield return null;
    }
    public IEnumerator FadeOut()
    {
        //fadeAmount += fadeSpeed * Time.deltaTime;
        ClampedFloatParameter cP = new ClampedFloatParameter(100, -200, 200, true);
        mixer.blueOutBlueIn = cP;
        mixer.blueOutGreenIn = cP;
        mixer.blueOutRedIn = cP;
        mixer.greenOutBlueIn = cP;
        mixer.greenOutGreenIn = cP;
        mixer.greenOutRedIn = cP;
        mixer.redOutBlueIn = cP;
        mixer.redOutGreenIn = cP;
        mixer.redOutRedIn = cP;
        mixer.SetDirty();
        yield return null;
    }
    */
}
    
