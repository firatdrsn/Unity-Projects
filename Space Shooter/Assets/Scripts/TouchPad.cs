using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float smoothingTouch;
    Vector2 originPosition;
    Vector2 direction,smoothDirection;
    bool touched;
    int pointerID;
    private void Awake()
    {
        touched = false;
        direction = Vector2.zero;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //baslangic noktamizi ayarlayacagimiz nokta
        if(!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
            originPosition = eventData.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //baslangic noktamiz ile su an oldugumuz noktayi karsilastiracagimiz kisim
        if(pointerID==eventData.pointerId)
        {
            Vector2 currentPosition = eventData.position;
            Vector2 directionRaw = currentPosition - originPosition;
            direction = directionRaw.normalized;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //herseyin sifirlanacagi kisim
        if(pointerID==eventData.pointerId)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }
    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothingTouch);
        return smoothDirection;
    }
}
