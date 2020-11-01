using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        int i = new System.Random().Next(0, sprites.Length);
        sr.sprite = sprites[i];
    }
}