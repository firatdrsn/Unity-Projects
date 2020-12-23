using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace DivisionGameExample
{
    public class PanelManager : MonoBehaviour
    {

        void Start()
        {
            gameObject.GetComponent<CanvasGroup>().DOFade(0, 1.5f);
        }

    }
}