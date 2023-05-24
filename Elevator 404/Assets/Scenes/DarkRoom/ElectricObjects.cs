using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricObjects : MonoBehaviour
{
    /*
    
    0 = lamp
    1 = battery
    2 = player controlled switch
    3 = relais
    4 = relais controlled switch
    5 = button
    6 = resistance
    */

    public int component;
    public bool conducting;
    public bool lampOn;
    public bool relaisOn;
    public List<GameObject> switches= new List<GameObject>();
    public ElectricController electricController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (component == 2) //player controlled switch
        {
            conducting = !conducting;
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.yellow);
        }
        else if (component == 5) //button
        {
            electricController.relais = 1;
            electricController.Calculate();
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
        }
    }

    public void Powered()
    {
        //this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.blue);
        if (component == 0) //lamp
        {
            lampOn = true;
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
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
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.cyan);
        }
    }

    public void RelaisReset()
    {
        relaisOn = false;
        for (int i = 0; i < switches.Count; i++)
        {
            switches[i].GetComponent<ElectricObjects>().RelaisSwitch();
            this.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.green);
        }
    }

    public void RelaisSwitch()
    {
        conducting = !conducting;
    }
}
