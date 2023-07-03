using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricObjects : MonoBehaviour
{
    /*
    
    0 = lamp
    1 = battery *
    2 = player controlled switch
    3 = relais
    4 = relais controlled switch
    5 = button
    6 = resistance *

    * removed
    
    */

    public int component;
    public bool conducting;
    public bool lampOn;
    public bool relaisOn;
    public List<GameObject> switches= new List<GameObject>();
    public ElectricController electricController;
    public Vector3 rotateSwitchAngle;
    public Material lampOnMat;

    public void Interact()
    {
        if (component == 2) //player controlled switch
        {
            conducting = !conducting;
            if (conducting)
            {
                this.transform.Rotate(rotateSwitchAngle);
            }
            else
            {
                this.transform.Rotate(new Vector3(0, 0, 0) - rotateSwitchAngle);
            }
            
            
        }
        else if (component == 5) //button
        {
            electricController.relais = 1;
            electricController.Calculate();
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
            StartCoroutine(changebackColor());
        }
    }

    public IEnumerator changebackColor ()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.white);
    }




    public void Powered()
    {
        //this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.blue);
        if (component == 0) //lamp
        {
            lampOn = true;
            
            this.transform.GetChild(0).GetComponent<Light>().enabled = true;
            GetComponent<Renderer>().material = lampOnMat;
        }
        else if (component == 3) //relais
        {
            if (relaisOn == false)
            {
                electricController.relais = 2;
                electricController.RelaisToReset.Add(this.gameObject);
                relaisOn = true;
                Relais();
                
            }
        }
    }

    public void Relais()
    {
        for (int i = 0; i < switches.Count; i++)
        {
            switches[i].GetComponent<ElectricObjects>().RelaisSwitch();
            
        }
    }

    public void RelaisReset()
    {
        relaisOn = false;
        for (int i = 0; i < switches.Count; i++)
        {
            switches[i].GetComponent<ElectricObjects>().RelaisSwitch();
            
        }
    }

    public void RelaisSwitch()
    {
        conducting = !conducting;
        if (conducting)
        {
            this.transform.Rotate(rotateSwitchAngle);
        }
        else
        {
            this.transform.Rotate(new Vector3(0, 0, 0) - rotateSwitchAngle);
        }
    }
}
