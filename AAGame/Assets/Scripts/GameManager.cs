using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    MainCircle mainCircle;
    CircleSpin circleSpin;
    public Animator animator;
    public Text levelText;
    public Text mainCircleText, subText_1, subText_2;
    public GameObject mainCircleObject, subCircle1Object, subCircle2Object;
    public int pinNumber;
    bool gameOverState;
    int nextLevel;
    void Start()
    {
        PlayerPrefs.SetInt("level",int.Parse(SceneManager.GetActiveScene().name));
        pinNumberControl();
        levelText.text = SceneManager.GetActiveScene().name;
        mainCircle = FindObjectOfType<MainCircle>();
        circleSpin = FindObjectOfType<CircleSpin>();
    }
    
    public void pinNumberControl()
    {
        if (pinNumber==0)
        {
            mainCircleText.text = "";
            mainCircleObject.SetActive(false);
            subCircle1Object.SetActive(false);
            subCircle2Object.SetActive(false);
            StartCoroutine(NextLevel());
        }
        else if(pinNumber<2)
        {
            mainCircleText.text = pinNumber.ToString();
            subText_1.text = "";
            subCircle1Object.SetActive(false);
            subText_2.text = "";
            subCircle2Object.SetActive(false);
        }
        else if(pinNumber<3)
        {
            mainCircleText.text = pinNumber.ToString();
            subText_1.text = (pinNumber - 1).ToString();
            subText_2.text = "";
            subCircle2Object.SetActive(false);
        }
        else
        {
            mainCircleText.text = pinNumber.ToString();
            subText_1.text = (pinNumber - 1).ToString();
            subText_2.text = (pinNumber - 2).ToString();
        }

    }
    public IEnumerator GameOver()
    {
        gameOverState = true;
        mainCircle.enabled = false;
        circleSpin.enabled = false;
        animator.SetTrigger("GameOver");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.1f);
        if (!gameOverState)
        {
            mainCircle.enabled = false;
            circleSpin.enabled = false;
            animator.SetTrigger("NextLevel");
            yield return new WaitForSeconds(1f);
            nextLevel = int.Parse(SceneManager.GetActiveScene().name)+1;
            if (nextLevel > 3)
                nextLevel = 0;
            SceneManager.LoadScene(nextLevel);
        }
    }
}
