using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScripts : MonoBehaviour
{

    AudioSource playerWeaponAudio;
    Rigidbody playerRB;
    float horizantolValue, verticalValue;
    [SerializeField]
    float speedValue=5f;
    GameManager gameManager;
    public float tiltValue = 2.5f;
    public float bulletReloadTime=0.5f;
    public float bulletFireTime;
    public GameObject bulletPrefabs;
    public Transform bulletDirectionTransform;
    Quaternion calibrationQuaternion;
    public TouchPad touchPad;
    public TouchFire touchFire;
    float zMin, zMax;
    float width;
    void Start()
    {
        CalibrateAccelerometer();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        playerWeaponAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        width = gameManager.widthCalculate();
        zMin = -8.5f;
        zMax = 7f;
    }

    private void Update()
    {
        //if(touchFire.GetFire() && Time.time>bulletFireTime)
        if(!gameManager.dead && Time.time > bulletFireTime)
        {
            bulletFireTime = Time.time+bulletReloadTime;
            Instantiate(bulletPrefabs,bulletDirectionTransform.position,Quaternion.identity);
            playerWeaponAudio.Play();
        }
    }
    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f,0f,-1f),accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }
    Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }
    void FixedUpdate()
    {
        
        //touchPad = GetComponent<TouchPad>();
        //horizantolValue = Input.GetAxis("Horizontal");
        //verticalValue = Input.GetAxis("Vertical");
        //playerRB.velocity = new Vector3(horizantolValue*speedValue,0,verticalValue*speedValue);

        //Accelerator Control
        //if(ButtonControl.accelerometerState)
        //{
        //    Vector3 accelerationRaw = Input.acceleration;
        //    Vector3 acceleration = FixAcceleration(accelerationRaw);
        //    playerRB.velocity = new Vector3(acceleration.x * speedValue, 0f, acceleration.y * speedValue);
        //}
            Vector2 direction = touchPad.GetDirection();
            playerRB.velocity = new Vector3(direction.x*speedValue, 0f, direction.y*speedValue);
        
        playerRB.position = new Vector3(Mathf.Clamp(playerRB.position.x, -width, width), 0,Mathf.Clamp(playerRB.position.z, zMin, zMax));
        playerRB.rotation = Quaternion.Euler(0,0,playerRB.velocity.x*-tiltValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.WhenThePlayerExplodes();
        }
    }
}
