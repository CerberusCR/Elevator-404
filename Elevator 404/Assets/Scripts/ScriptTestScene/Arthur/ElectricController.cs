using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElectricController : MonoBehaviour
{
    public int correctPaths;
    public List<int> lowestResistancePaths;
    public List<GameObject> RelaisToReset;
    public int lowestResistancevalue;
    public int relais;
    public bool lampOn;
    public GameObject fire;
    
    

    //public GameObject[][] paths = new GameObject[4][];

    public List<Path> paths = new();

    [System.Serializable]
    public class Path
    {
        public List<GameObject> components = new();
        public int resistances;
        public bool pathIsActive;
    }

    public void Calculate()
    {
        while (relais > 0)
        {
            lampOn = false;
            correctPaths = 0;
            lowestResistancevalue = int.MaxValue;
            for (int i = 0; i < paths.Count; i++)
            {
                paths[i].pathIsActive = true;
                for (int j = 0; j < paths[i].components.Count; j++)
                {
                    if (!paths[i].components[j].GetComponent<ElectricObjects>().conducting)
                    {
                        paths[i].pathIsActive = false;
                        break;
                    }
                }
                if (paths[i].pathIsActive)
                {
                    correctPaths++;
                    if (paths[i].resistances < lowestResistancevalue)
                    {
                        lowestResistancePaths.Clear();
                        lowestResistancePaths.Add(i);
                        lowestResistancevalue = paths[i].resistances;
                    }
                    else if (paths[i].resistances == lowestResistancevalue)
                    {
                        lowestResistancePaths.Add(i);
                    }
                }
            }
            if (correctPaths > 0)
            {
                for (int i = 0; i < lowestResistancePaths.Count; i++)
                {
                    for (int j = 0; j < paths[lowestResistancePaths[i]].components.Count; j++)
                    {
                        paths[lowestResistancePaths[i]].components[j].GetComponent<ElectricObjects>().Powered();
                    }
                }
            }
            relais--;
        }
        if (lampOn == false)
        {
            StartCoroutine(RelaisReset());
        }
        else
        {
            fire.GetComponent<StartFire>().TestFire();
        }
    }

    public IEnumerator RelaisReset()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < RelaisToReset.Count; i++)
        {
            RelaisToReset[i].GetComponent<ElectricObjects>().RelaisReset();
        }
        RelaisToReset.Clear();
    }
}
