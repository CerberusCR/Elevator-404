using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout2 : MonoBehaviour
{
    public Image blackscreen;
    public Color imageColor;
    public float fadeAmount = 1f;

    public void Start()
    {
        imageColor = blackscreen.GetComponent<Image>().color;
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
        fadeAmount= 0f;
        while (fadeAmount < 1)
        {
            fadeAmount += Time.deltaTime;
            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
            blackscreen.GetComponent<Image>().color = imageColor;
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        fadeAmount = 1f;
        while (fadeAmount > 0)
        {
            fadeAmount -= Time.deltaTime;
            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
            blackscreen.GetComponent<Image>().color = imageColor;
            yield return null;
        }
    }
}
