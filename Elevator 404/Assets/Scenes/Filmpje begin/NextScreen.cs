using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreen : MonoBehaviour
{
    public GameObject plaatje1;
    public GameObject knop1;
    public GameObject plaatje2;
    public GameObject knop2;
    public GameObject plaatje3;
    public GameObject knop3;
    public GameObject plaatje4;
    public GameObject knop4;


    public void GoToNextScreen1To2()
    {
        plaatje1.SetActive(false);
        knop1.SetActive(false);

        plaatje2.SetActive(true);
        knop2.SetActive(true);
    }

    public void GoToNextScreen2To3()
    {
        plaatje2.SetActive(false);
        knop2.SetActive(false);

        plaatje3.SetActive(true);
        knop3.SetActive(true);
    }

    public void GoToNextScreen3To4()
    {
        plaatje3.SetActive(false);
        knop3.SetActive(false);

        plaatje4.SetActive(true);
        knop4.SetActive(true);
    }
}
