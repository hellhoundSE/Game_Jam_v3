using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permutatuion : MonoBehaviour
{
    public void Permutate()
    {
        GunBehaviour temp = GunsLibrary.list[0].Behaviour;

        for(int i = 0; i < GunsLibrary.list.Count - 1; i++)
        {
            GunsLibrary.list[i].Behaviour = BehavioursLibrary.list[i + 1];
        }
        GunsLibrary.list[GunsLibrary.list.Count - 1].Behaviour = temp;
    }

    void Start()
    {
        InvokeRepeating("Permutate", 0f, 30f);
    }
}
