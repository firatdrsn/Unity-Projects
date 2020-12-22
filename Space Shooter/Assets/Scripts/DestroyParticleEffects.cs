using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleEffects : MonoBehaviour
{
    public float destroyExplosionTime = 2f;
    void Start()
    {
        Destroy(gameObject,destroyExplosionTime);
    }

}
