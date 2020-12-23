using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdManager : MonoBehaviour
{
    int score=0,highScore=0;
    Text scoreText;
    public static bool firstScene = true;
    public static bool dead=false;
    Rigidbody2D birdRB;
    AudioSource[] sounds;
    AudioSource crashSound,scoreSound;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("high score "+highScore);
        sounds = GetComponents<AudioSource>();
        crashSound = sounds[1];
        scoreSound = sounds[2];
        birdRB = gameObject.GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("ScoreText").gameObject.GetComponent<Text>();
        scoreText.text = "Score = "+score;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="ScoreArea")
        {
            score++;
            scoreSound.Play();
            scoreText.text = "Score = " + score;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Pipe" || collision.tag=="Platform")
        {
            dead = true;
            crashSound.Play();
            GetComponent<CapsuleCollider2D>().enabled = false;
            if(score>highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
               
            }
            Invoke("ReturnMenu",2f);
        }
    }
    
    void ReturnMenu()
    {
        PlayerPrefs.SetInt("Score",score);
        firstScene = false;
        SceneManager.LoadScene("MenuScene");
    }
}
