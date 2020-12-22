using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d
{
    public class GroundManager : MonoBehaviour
    {
        [SerializeField]
        float startPoint, endPoint;
        float currentPoint;
        float xPosition;
        bool left;
        void Start()
        {
            currentPoint = endPoint;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //if(transform.position.x<=127f && transform.position.x >= 114f && left)
            //{
            //    GetComponent<Rigidbody2D>().velocity = new Vector2(-2f,0);
            //}
            //else
            //{
            //    left = false;
            //}
            //if(transform.position.x >= 112f && transform.position.x < 125f && !left)
            //{
            //    GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0);
            //}
            //else
            //{
            //    left = true;
            //}

            xPosition = Mathf.Clamp(currentPoint, startPoint, endPoint);
            transform.position = new Vector3(xPosition, transform.position.y, 0);

            if (currentPoint > startPoint && !left)
            {
                currentPoint -= 0.2f;
            }
            else
            {
                left = true;
            }
            if (currentPoint < endPoint && left)
            {
                currentPoint += 0.2f;
            }
            else
            {
                left = false;
            }
        }
    }
}