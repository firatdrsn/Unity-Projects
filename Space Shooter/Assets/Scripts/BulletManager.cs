using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    Rigidbody bulletRB;
    public float bulletSpeed=10;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward*bulletSpeed;
    }


}
