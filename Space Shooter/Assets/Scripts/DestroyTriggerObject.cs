using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTriggerObject : MonoBehaviour
{
    public GameObject explosionParticle;
    public int destroyScoreValue;
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "EnemyBullet" || other.tag=="Enemy" || other.tag=="Asteroid")
            return;
        if (other.tag == "Bullet")
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManager.ScoreCalculator(destroyScoreValue);
        }
        if (other.tag == "Player")
        {
            gameManager.WhenThePlayerExplodes();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
