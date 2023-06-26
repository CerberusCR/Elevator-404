using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keycode : MonoBehaviour
{
    public int number;
    public GameObject controller;
    public void Interact()
    {
        //controller.GetComponent<>()
    }
    public void ColorSwitch()
    {
        StartCoroutine(ColorSwitchBack());
        this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.green);
    }
    public IEnumerator ColorSwitchBack()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.white);
    }
}
