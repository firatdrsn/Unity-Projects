using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    int level;
    private void Start()
    {
        level = PlayerPrefs.GetInt("level");
        if (level == 0 || level==1)
        {
            level = 1;
            GameObject.Find("ContinueGameButton").SetActive(false);
        }
    }
    public void ContinueButton()
    {
        if (level >= 3)
            level = 3;
        SceneManager.LoadScene(level);
    }
    public void NewGameButton()
    {
        PlayerPrefs.DeleteKey("level");
        level = 1;
        SceneManager.LoadScene(level);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
