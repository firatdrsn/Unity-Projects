using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Vector3 startBackgroundPosition;
    float newBackgroundPosition;
    public float backgroundSpeed = 2f; 
    float backgroundLength;
    void Start()
    {
        backgroundLength = GetComponent<BoxCollider2D>().size.x;
        startBackgroundPosition = transform.position;
    }

    void Update()
    {
        if(!BirdManager.dead)
        {
            newBackgroundPosition = Mathf.Repeat(Time.time * backgroundSpeed, backgroundLength);
            transform.position = startBackgroundPosition + Vector3.left * newBackgroundPosition;
        }
    }
}
