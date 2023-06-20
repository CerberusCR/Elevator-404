using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout2 : MonoBehaviour
{
    public Image blackscreen;
    public Color imageColor;
    public float fadeAmount = 0.5f;

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
        while (true)
        {
            fadeAmount += 0.1f;
            imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
            blackscreen.GetComponent<Image>().color = imageColor;
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        fadeAmount -= 0.1f;
        imageColor = new Color(imageColor.r, imageColor.g, imageColor.b, fadeAmount);
        blackscreen.GetComponent<Image>().color = imageColor;
        yield return null;
    }
}
