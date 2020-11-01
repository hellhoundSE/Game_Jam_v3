using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehavioursLibrary : MonoBehaviour
{
    public List<GameObject> privateList;

    public static List<GunBehaviour> list = new List<GunBehaviour>();

    public void Start()
    {

        foreach(var item in privateList)
        {
            list.Add(item.GetComponent<GunBehaviour>());
        }
    }

}
