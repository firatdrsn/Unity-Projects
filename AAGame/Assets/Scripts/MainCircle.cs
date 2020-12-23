using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{
    public GameObject pin;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            gameManager.pinNumber--;
            gameManager.pinNumberControl();
            Instantiate(pin,transform.position,Quaternion.identity);
        }
    }
}
