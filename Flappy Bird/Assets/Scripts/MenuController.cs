using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    Text highScore,yourScore;
    void Start()
    {
        BirdManager.dead = false;
        highScore = GameObject.Find("HighScoreText").GetComponent<Text>();
        yourScore = GameObject.Find("YourScoreText").GetComponent<Text>();
        highScore.text = "High Score = "+PlayerPrefs.GetInt("HighScore").ToString();
        if(!BirdManager.firstScene)
        {
            yourScore.text = "Your Score = "+PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            PlayerPrefs.DeleteKey("Score");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
