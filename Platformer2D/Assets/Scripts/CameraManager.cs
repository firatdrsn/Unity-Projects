using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float cameraSpeed;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
            {
                //transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);

                transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y + 2f, transform.position.z), cameraSpeed);
            }
        }
    }
}