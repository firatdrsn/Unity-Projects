using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float backgroundSpeed = -2f;
    public float backgroundLength = 20f;
    Vector3 startBackgroundPosition;
    void Start()
    {
        startBackgroundPosition = transform.position;
    }

    void Update()
    {
        float newBackgroundPosition = Mathf.Repeat(Time.time*backgroundSpeed,backgroundLength);
        transform.position = startBackgroundPosition + Vector3.forward * newBackgroundPosition;
    }
}
