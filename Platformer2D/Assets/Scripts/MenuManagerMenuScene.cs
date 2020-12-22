using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer2d
{
    public class MenuManagerMenuScene : MonoBehaviour
    {
        [SerializeField] GameObject dataBoard;

        public void PlayButton()
        {
            SceneManager.LoadScene(1);
        }
        public void DataBoardButton()
        {
            DataManager.Instance.LoadData();
            dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Shot Bullet = " + DataManager.Instance.totalShotBullet.ToString();
            dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed = " + DataManager.Instance.totalEnemyKilled.ToString();
            dataBoard.SetActive(true);
        }
        public void ExitButton()
        {
            dataBoard.SetActive(false);
        }
    }
}