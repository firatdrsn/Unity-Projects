using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeuver : MonoBehaviour
{
    public Vector2 startWait, maneuverTime, maneuverWait;
    public float dodge,smoothing,tiltValue;
    float zMin, zMax, width;
    Rigidbody enemyRB;
    GameManager gameManager;
    float targetManeuver, currentSpeed;
    void Start()
    {
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
        width = gameManager.widthCalculate();
        zMin = -12;
        zMax = 10;
        enemyRB = GetComponent<Rigidbody>();
        currentSpeed = enemyRB.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x,startWait.y));
        while(true)
        {
            targetManeuver = Random.Range(1,dodge)*-Mathf.Sign(transform.position.x);//Mathf.Sing() parametre olarak gelen deger negatif ise -1 pozitif ise 1 degerini dondurur
            yield return new WaitForSeconds(Random.Range(maneuverTime.x,maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x,maneuverWait.y));
        }
    }
    private void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(enemyRB.velocity.x,targetManeuver,Time.deltaTime*smoothing);
        enemyRB.velocity = new Vector3(newManeuver, 0f, currentSpeed);
        enemyRB.position = new Vector3(
            Mathf.Clamp(enemyRB.position.x,-width,width),
            0f,
            Mathf.Clamp(enemyRB.position.z,zMin,zMax));
        enemyRB.rotation = Quaternion.Euler(0f,0f,enemyRB.velocity.x*-tiltValue);
    }
}
