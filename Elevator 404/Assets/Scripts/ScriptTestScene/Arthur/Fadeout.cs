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
    public GameObject postprocessingGlobal;
    public ChannelMixer mixer;

    public void Start()
    {
        //hulp nodig
        //mixer = postprocessingGlobal.GetComponent<Volume>().profile.components[0].;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(FadeBlackOutSquare());
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeBlackOutSquare(false));
        }
    }
    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        
        float fadeAmount = 100;
        if (fadeToBlack)
        {
            while (fadeAmount > 0)
            {
                fadeAmount -= fadeSpeed * Time.deltaTime;
                ClampedFloatParameter cP = new ClampedFloatParameter(fadeAmount, -200, 200);
                mixer.blueOutBlueIn = cP;
                mixer.blueOutGreenIn = cP;
                mixer.blueOutRedIn = cP;
                mixer.greenOutBlueIn = cP;
                mixer.greenOutGreenIn = cP;
                mixer.greenOutRedIn = cP;
                mixer.redOutBlueIn = cP;
                mixer.redOutGreenIn = cP;
                mixer.redOutRedIn = cP;
                yield return null;
            }
        }
        else
        {
            while (fadeAmount < 100)
            {
                fadeAmount += fadeSpeed * Time.deltaTime;
                ClampedFloatParameter cP = new ClampedFloatParameter(fadeAmount, -200, 200);
                mixer.blueOutBlueIn = cP;
                mixer.blueOutGreenIn = cP;
                mixer.blueOutRedIn = cP;
                mixer.greenOutBlueIn = cP;
                mixer.greenOutGreenIn = cP;
                mixer.greenOutRedIn = cP;
                mixer.redOutBlueIn = cP;
                mixer.redOutGreenIn = cP;
                mixer.redOutRedIn = cP;
                yield return null;
            }
        }
    }
}
    
