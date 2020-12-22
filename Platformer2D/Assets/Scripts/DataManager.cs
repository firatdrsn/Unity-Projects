using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

namespace Platformer2d
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        private int shotBullet;
        public int totalShotBullet;
        private int enemyKilled;
        public int totalEnemyKilled;
        EasyFileSave myFile;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;//daha once olusturulmus instance nesnesi yoksa bu datamanager nesnesini ona atiyoruz
                StartProcess();
            }
            else
            {
                Destroy(gameObject);//Eger var olan bir kayit varsa yeni olusturdugumuz instance nesnesini siliyoruz
            }
            DontDestroyOnLoad(gameObject);//her sahnede oldugu gibi kullanmak icin bu methodu kullaniyoruz. instance nesnesinin silinmesini engelliyor
        }


        public int ShotBullet
        {
            get
            {
                return shotBullet;
            }
            set
            {
                shotBullet = value;
                GameObject.Find("ShotBulletText").GetComponent<Text>().text = "Shot Bullet = " + shotBullet.ToString();
            }
        }
        public int EnemyKilled
        {
            get
            {
                return enemyKilled;
            }
            set
            {
                enemyKilled = value;
                GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "Enemy Killed = " + enemyKilled.ToString();
            }
        }
        public void StartProcess()
        {
            myFile = new EasyFileSave();
            LoadData();
        }
        public void SaveData()
        {
            totalShotBullet += shotBullet;
            totalEnemyKilled += enemyKilled;
            shotBullet = 0;
            enemyKilled = 0;
            myFile.Add("totalShotBullet", totalShotBullet);
            myFile.Add("totalEnemyKilled", totalEnemyKilled);

            myFile.Save();
        }
        public void LoadData()
        {
            if (myFile.Load())
            {
                totalShotBullet = myFile.GetInt("totalShotBullet");
                totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
            }
        }
    }
}