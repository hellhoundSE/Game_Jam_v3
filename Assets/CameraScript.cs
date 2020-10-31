using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;

    public Vector2 maxDeviationFromStartingPoint;
    public float followingSpeed_lerp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPosition = 
            Vector2.Lerp(
                new Vector2(transform.position.x, transform.position.y), 
                new Vector2(player.transform.position.x, player.transform.position.y),
                followingSpeed_lerp);
        transform.position = 
            new Vector3(
                Mathf.Clamp(newPosition.x, -maxDeviationFromStartingPoint.x, maxDeviationFromStartingPoint.x),
                Mathf.Clamp(newPosition.y, -maxDeviationFromStartingPoint.y, maxDeviationFromStartingPoint.y),
                transform.position.z);
    }
}