using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DivisionGameExample
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        Text scoreText;
        int scoreValue, totalScore;
        void Start()
        {
            scoreText.text = totalScore.ToString();
        }

        public void CalculateScore(string difficulty)
        {
            switch (difficulty)
            {
                case "easy":
                    scoreValue = 5;
                    totalScore += scoreValue;
                    scoreText.text = totalScore.ToString();
                    break;
                case "normal":
                    scoreValue = 10;
                    totalScore += scoreValue;
                    scoreText.text = totalScore.ToString();
                    break;
                case "hard":
                    scoreValue = 15;
                    totalScore += scoreValue;
                    scoreText.text = totalScore.ToString();
                    break;
            }
        }
        public int GetScore()
        {
            return totalScore;
        }
    }
}