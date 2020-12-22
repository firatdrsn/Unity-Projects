using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d
{
    public class BulletManager : MonoBehaviour
    {
        public float bulletDamage;
        [SerializeField] float lifeTime;
        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

    }

}
