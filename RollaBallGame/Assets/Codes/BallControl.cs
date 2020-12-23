using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class BallControl : MonoBehaviour
{
    [SerializeField] Rigidbody physic;
    [SerializeField] int ballSpeed=10;
    [SerializeField] int allCoin=8;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finishText;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Joystick joystick;
    bool plane;
    void Start()
    {
        plane = false;
        physic =GetComponent<Rigidbody>();//Topumuzun rigidboy componentini cekip physic adli degiskene atiyoruz
    }

    public void Jump()
    {
        buttonText.color = Color.blue;
        if (plane)
            physic.AddForce(new Vector3(0,400,0));
    }
    void FixedUpdate()//belirli aralıklarla update ediyor
    {
        // buttonText.color = Color.red;

        if (physic != null)
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); //klavye yatay yonlendirme
            if (joystick.Horizontal <= -.2f || joystick.Horizontal >= .2f)
            {
                horizontal = joystick.Horizontal;//joystick yatay yonlendirme  
            }
            else
            {
                horizontal = 0;
            }
            float vertical = Input.GetAxisRaw("Vertical"); //klavye dikey yonlendirme
            if (joystick.Vertical <= -.2f || joystick.Vertical >= .2f)
            {
                vertical = joystick.Vertical;//joystick dikey yonlendirme 
            }
            else
            {
                vertical = 0;
            }
            Vector3 vector = new Vector3(horizontal, 0, vertical);//vektor ile yonlendirme
            physic.AddForce(vector * ballSpeed);//topa uygulanan kuvvet. hiz degiskeni ile kuvvetin gucu arttirilarak hizlanmasi saglaniyor
            if (physic.velocity.y > 1)
            {
                plane = false;
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Plane")
        {
            plane = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            score++;
            scoreText.text = "Score = " + score;
            other.gameObject.SetActive(false);
            if (score == allCoin)
            {
                finishText.color = Color.red;
                finishText.text = "Game Complete";
                Time.timeScale = 0;
            }
        }
        
    }
}
