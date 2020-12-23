using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject[] pipes;
    [SerializeField]GameObject pipe;
    [SerializeField]int pipesNumber=5;
    float yAxis,width,screenWidth,screenHeight;
    void Start()
    {
        pipes = new GameObject[pipesNumber];
        StartCoroutine(RandomYAxis());
    }
    void xAxis()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        width = (Camera.main.orthographicSize * screenWidth / screenHeight) + 1;
    }
    void Update()
    {
        if (BirdManager.dead)
        {
            StopCoroutine(RandomYAxis());
            foreach (var item in pipes)
            {
                if(item!=null)
                    item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
    IEnumerator RandomYAxis()
    {
        xAxis();
        for (int i = 0; i < pipesNumber; i++)
        {
            yAxis = Random.Range(-2.41f, 6.6f);
            if (!BirdManager.dead)
            {
                pipes[i] = Instantiate(pipe, new Vector3(width, yAxis), Quaternion.identity);
                pipes[i].AddComponent<Rigidbody2D>();
                pipes[i].GetComponent<Rigidbody2D>().gravityScale = 0;
                pipes[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-GameObject.FindObjectOfType<BackgroundScroll>().backgroundSpeed, 0);
                yield return new WaitForSeconds(1.5f);
            }
        }
        while (!BirdManager.dead)
        {
            xAxis();
            foreach (GameObject item in pipes)
            {
                if(!BirdManager.dead)
                {
                    yAxis = Random.Range(-2.41f, 6.6f);
                    item.transform.position = new Vector3(width, yAxis);
                    yield return new WaitForSeconds(1.5f);
                }
                    
            }
        }
    }
}
