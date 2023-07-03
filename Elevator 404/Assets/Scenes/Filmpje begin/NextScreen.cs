using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreen : MonoBehaviour
{
    public GameObject plaatje1;
    public GameObject knop1;
    public GameObject plaatje2;
    public GameObject knop2;
    public void GoToNextScreen()
    {
        plaatje1.SetActive(false);
        knop1.SetActive(false);

        plaatje2.SetActive(true);
        knop2.SetActive(true);
    }
}
