using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsLibrary : MonoBehaviour
{

    public List<GameObject> privateList;

    public static List<Gun> list = new List<Gun>();
    public static List<GameObject> prefabs;

    public void Start()
    {
        prefabs = privateList;

        foreach (var item in privateList)
        {
            list.Add(item.GetComponent<Gun>());
        }
    }    

}
