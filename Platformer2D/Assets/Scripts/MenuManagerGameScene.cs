using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2d
{
    public class MenuManagerGameScene : MonoBehaviour
    {
        [SerializeField] GameObject inGameScreen, pauseScreen;
        [SerializeField] GameObject player;

        void Update()
        {
            if (player != null)
            {
                if (player.GetComponent<PlayerManager>().WinnerScreen.activeSelf)//winnerscreen aktif ise ingamescreeni devre disi birak
                {
                    inGameScreen.SetActive(false);
                }
            }
            else//player oldugunde death screen calisacagi icin ingame screen false yapildi
            {
                inGameScreen.SetActive(false);
            }
        }
        public void PauseButton()
        {
            //player.GetComponent<PlayerManager>().enabled = false; karakterin scriptini devre disi birakiyorduk. ates etmesini onlemek icin
            Time.timeScale = 0;
            inGameScreen.SetActive(false);
            pauseScreen.SetActive(true);
        }
        public void ResumeButton()
        {
            //player.GetComponent<PlayerManager>().enabled = true; bu kisimda tekrar aktif edip ates etmesini sagliyorduk
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            inGameScreen.SetActive(true);
        }
        public void RestartButton()
        {
            Time.timeScale = 1;
            DataManager.Instance.SaveData();
            SceneManager.LoadScene(1);
        }
        public void HomeButton()
        {
            Time.timeScale = 1;
            DataManager.Instance.SaveData();
            SceneManager.LoadScene(0);
        }
    }
}