using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d
{
    public class DestroyMe : MonoBehaviour
    {
        [SerializeField] float lifeTime;
        void Start()
        {
            if (gameObject.tag == "Bullet")
            {

                Destroy(gameObject, lifeTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                gameObject.transform.position = new Vector2(2, 0);
            }
        }

    }
}