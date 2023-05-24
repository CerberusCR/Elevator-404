using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Electricity", order = 1)]
public class Paths : ScriptableObject
{
    public List<Path> paths = new();

    [System.Serializable]
    public class Path
    {
        public List<GameObject> components = new();
        public int resistances;
    }
}
