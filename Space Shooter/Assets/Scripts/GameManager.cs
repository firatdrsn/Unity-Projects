using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class GameManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    Vector3 asteroidCreatePosition;//x=6,y=0,z=10
    int score,levelSpeed=500;
    Text scoreText;
    public Text cupText,awardText;
    public GameObject gameOverText,restartGameText;
    public bool dead;
    public GameObject playerExplosionParticle;
    public Transform playerTransform;
    public GameObject restartButton;
    public Sprite redCup, greenCup, yellowCup, blueCup;
    public Image cupImage;
    float width, screenWidth, screenHeight;
    public GameObject backgroundImage2, backgroundImage3;
    public float widthCalculate()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        width = Camera.main.orthographicSize * 2.0f * screenWidth / screenHeight;
        width = (width / 2) - 0.5f;
        return width;
    }
    void Start()
    {
        width=widthCalculate();
        if (screenHeight==800)
        {
            backgroundImage3.SetActive(true);
            backgroundImage2.SetActive(false);
        }

        asteroidCreatePosition = new Vector3(width,0,10);
        restartButton.SetActive(false);
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        StartCoroutine(CreateAsteroidRoutine());
    }
    IEnumerator CreateAsteroidRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (!dead)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0,asteroidPrefabs.Length)];
                Vector3 asteroidRandomPosition= new Vector3(Random.Range(-asteroidCreatePosition.x, asteroidCreatePosition.x), 0, asteroidCreatePosition.z);
                Instantiate(asteroidPrefab, asteroidRandomPosition, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(3f);
        }
    }
    //private void FixedUpdate()
    //{
    //    //if(Input.GetKeyDown(KeyCode.R) && dead)
    //    //{
    //    //    AsteroidManager.asteroidMovementSpeed = AsteroidManager.startAsteroidMovementSpeed;
    //    //    levelSpeed = 100;
    //    //    SceneManager.LoadScene("SampleScene");
    //    //}
    //}
    public void ScoreCalculator(int incomingScore)
    {
        score += incomingScore;
        scoreText.text = "Puan = "+score.ToString();
        GameSpeed();
    }
    void GameSpeed()
    {
        if (score >= levelSpeed)
        {
            AsteroidManager.asteroidMovementSpeed += 1f;
            levelSpeed *= 2;
        }
    }
    public void WhenThePlayerExplodes()
    {
        Instantiate(playerExplosionParticle, playerTransform.position, playerTransform.rotation);
        gameOverText.SetActive(true);
        //restartGameText.SetActive(true);
        restartButton.SetActive(true);
        if(score<500)
        {
            cupImage.GetComponent<Image>().sprite = redCup;
            awardText.text = "Kırmızı Teselli kupası aldın";
        }
        else if(score<2500)
        {
            cupImage.sprite = greenCup;
            awardText.text = "Yetenekli kupasını hak ettin";
        }
        else if(score<5000)
        {
            cupImage.sprite = yellowCup;
            awardText.text = "Tebrikler, Profesyonellik kupasını Kazandın";
        }
        else
        {
            cupImage.GetComponent<Image>().sprite = blueCup;
            awardText.text = "Bir EFSANE Olarak Tarihe Geçtin!!!";
        }
        cupImage.gameObject.SetActive(true);
        cupText.text = score.ToString();
        dead = true;
    }
    public void RestartGame()
    {
        AsteroidManager.asteroidMovementSpeed = AsteroidManager.startAsteroidMovementSpeed;
        levelSpeed = 500;
        SceneManager.LoadScene("SpaceShooter");
    }
}
