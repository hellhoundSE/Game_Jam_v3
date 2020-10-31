using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropppedGun : MonoBehaviour
{
    public Gun Gun;

    public Sprite sprite;


    public void Start()
    {
        sprite = gameObject.GetComponent<Sprite>();

    }


}
