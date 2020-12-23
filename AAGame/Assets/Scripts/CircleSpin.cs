using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpin : MonoBehaviour
{
    public float speed = 100f;
    public GameObject pin;
    bool temas;
    
    void Update()
    {
        transform.Rotate(0,0,speed*Time.deltaTime);
    }

}
