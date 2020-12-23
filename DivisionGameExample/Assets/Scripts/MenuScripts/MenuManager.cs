using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
namespace DivisionGameExample
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject startButton, exitButton;
        void Start()
        {
            FadeIn();
        }

        void FadeIn()
        {
            startButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
            exitButton.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
        }
        public void ExitApplication()
        {
            Application.Quit();
        }
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}