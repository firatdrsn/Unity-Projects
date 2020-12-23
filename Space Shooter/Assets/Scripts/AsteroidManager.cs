using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AsteroidManager : MonoBehaviour
{
    Rigidbody asteroidRB;
    public float asteroidRotationSpeed = 3f;
    public static float asteroidMovementSpeed = 5f;
    public static float startAsteroidMovementSpeed = 5f;
    void Start()
    {
        asteroidRB = GetComponent<Rigidbody>();
        asteroidRB.angularVelocity = Random.insideUnitSphere*asteroidRotationSpeed;
        asteroidRB.velocity = Vector3.back * asteroidMovementSpeed;
    }

}
