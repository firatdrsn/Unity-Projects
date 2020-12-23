using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
namespace DivisionGameExample
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        GameObject squarePrefabs;
        [SerializeField]
        Transform squarePanel;
        [SerializeField]
        GameObject life;
        [SerializeField]
        Transform dashboard;
        [SerializeField]
        Transform questionPanel;
        List<GameObject> squareList = new List<GameObject>();
        List<int> numberList = new List<int>();
        int dividend, divisor, quotient; //dividend = Bölünen, divisor = Bölen, quotient = Bölüm
        int listIndex, buttonValue, answer;
        bool buttonState = false;
        GameObject buttonNumber;
        int lifeNumber = 3;
        string questionDifficulty;
        ScoreManager scoreManager;
        [SerializeField]
        Transform resultPanel;
        Text totalScoreText;
        [SerializeField]
        AudioClip buttonClickSound;
        void Start()
        {
            scoreManager = Object.FindObjectOfType<ScoreManager>();
            questionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
            SquareCreate();
            StartCoroutine(SquareRoutine());
            SquareNumberFill();
            Invoke("QuestionPanelScale", 1f);
            Invoke("LifeCreate", 0.9f);
        }
        void SquareCreate()
        {
            for (int i = 0; i < 25; i++)
            {
                squareList.Add(Instantiate(squarePrefabs, squarePanel));
                squareList[i].transform.GetComponent<Button>().onClick.AddListener(() => ClickAnswer());
            }

        }
        IEnumerator SquareRoutine()
        {
            foreach (var item in squareList)
            {
                item.GetComponent<CanvasGroup>().DOFade(1, 1f);
                yield return new WaitForSeconds(0.05f);
            }
        }
        void SquareNumberFill()
        {
            foreach (var square in squareList)
            {
                int number = Random.Range(1, 13);
                numberList.Add(number);
                square.transform.GetChild(0).GetComponent<Text>().text = number.ToString();

            }
        }
        void ClickAnswer()
        {
            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            buttonNumber = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
            if (buttonState && buttonValue == answer)
            {
                scoreManager.CalculateScore(questionDifficulty);
                numberList.RemoveAt(listIndex);
                buttonNumber.transform.GetChild(1).GetComponent<Image>().enabled = true;
                buttonNumber.transform.GetChild(0).GetComponent<Text>().enabled = false;
                buttonNumber.GetComponent<Button>().interactable = false;
                if (numberList.Count > 0)
                {
                    QuestionCreate();
                }
                else
                {
                    ResultPanel();
                }
            }
            else if (buttonState && lifeNumber != 0)
            {
                dashboard.GetChild(lifeNumber - 1).GetComponent<LifeManager>().killLife();
                lifeNumber--;
            }
            if (buttonState && lifeNumber <= 0)
            {
                ResultPanel();
            }
        }
        void ResultPanel()
        {
            buttonState = false;
            resultPanel.GetChild(2).GetChild(0).GetComponent<Text>().text = "Score : " + scoreManager.GetScore().ToString();
            resultPanel.gameObject.SetActive(true);
        }
        void QuestionPanelScale()
        {
            questionPanel.GetComponent<RectTransform>().DOScale(1, 2f).SetEase(Ease.OutBack);
            QuestionCreate();
        }
        void QuestionCreate()
        {
            divisor = Random.Range(2, 11);
            listIndex = Random.Range(0, numberList.Count);
            dividend = divisor * numberList[listIndex];
            //questionPanel.GetChild(0).GetComponent<Text>().text = dividend + " / " + divisor;
            questionPanel.Find("QuestionText").GetComponent<Text>().text = dividend + " / " + divisor;
            answer = numberList[listIndex];
            if (dividend <= 40)
            {
                questionDifficulty = "easy";
            }
            else if (dividend > 40 && dividend <= 80)
            {
                questionDifficulty = "normal";
            }
            else
            {
                questionDifficulty = "hard";
            }
        }
        void LifeCreate()
        {
            for (int i = 0; i < lifeNumber; i++)
            {
                Instantiate(life, dashboard);
            }
            buttonState = true;
        }
    }
}