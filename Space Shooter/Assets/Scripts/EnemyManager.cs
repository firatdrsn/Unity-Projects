using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    Rigidbody enemyRB;
    public GameObject enemyBullet;
    public Transform enemyMuzzle;
    public static float enemyMovementSpeed = 5f;
    private AudioSource audioSource;
    public float enemyShootTime = 0.5f, enemyReloadTime = 1f;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        enemyRB.velocity = Vector3.back * enemyMovementSpeed;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("enemyFire",enemyShootTime,enemyReloadTime);
    }

    void enemyFire()
    {
        Instantiate(enemyBullet,enemyMuzzle.position,enemyMuzzle.rotation);
        audioSource.Play();
    }

}
