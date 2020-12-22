using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2d
{
    public class DeadSpace : MonoBehaviour
    {


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerManager>().health = 0;
                other.GetComponent<PlayerManager>().AmIDead();
            }
            else if (other.tag == "Enemy" || other.tag == "Enemy2")
            {
                other.GetComponent<EnemyManager>().DeadSpaceKill();
            }
        }
    }
}