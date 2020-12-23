using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody2D pinRB;
    public float pinSpeed = 5f;
    bool pinMoveState=false;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        pinRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(!pinMoveState)
        {
            pinRB.MovePosition(pinRB.position + Vector2.up * pinSpeed * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="SpinningCircle") 
        {
            pinMoveState = true;
            transform.SetParent(collision.transform);
        }
        if(collision.tag=="Pin")
        {
            StartCoroutine(gameManager.GameOver());
        }
    }
}
