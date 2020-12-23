using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DivisionGameExample
{
    public class ResultManager : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }
        public void HomeScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}