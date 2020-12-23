using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DivisionGameExample
{
    public class LifeManager : MonoBehaviour
    {

        public void killLife()
        {
            Destroy(gameObject);
        }
    }
}