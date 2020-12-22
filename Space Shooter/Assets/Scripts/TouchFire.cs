using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TouchFire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool touched;
    bool fire;
    int pointerID;
    private void Awake()
    {
        touched = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
            fire = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(pointerID==eventData.pointerId)
        {
            touched = false;
            fire = false;
        }
    }
    public bool GetFire()
    {
        return fire;
    }
}
