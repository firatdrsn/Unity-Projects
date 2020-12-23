using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    //[Header("Code Animation Sprites")]
    //[SerializeField] Sprite[] birdSprite;
    //SpriteRenderer spriteRenderer;
    //bool retryControl;
    //int birdCounter;
    //[SerializeField] float birdAnimationSpeed;
    [Header("Physic Settings")]
    Rigidbody2D birdRB;
    [SerializeField]float upFlying;
    AudioSource whirSound;
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //birdCounter = 0;
        whirSound = GetComponent<AudioSource>();
        birdRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log("dead durumu "+BirdManager.dead);
        //Animation(); //Code animation
        if(Input.GetMouseButtonDown(0) && !BirdManager.dead)
        {
            birdRB.velocity = new Vector2(0, 0);
            birdRB.AddForce(new Vector2(0,upFlying));
            whirSound.Play();
        }
        if(birdRB.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0,0,45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0,0,-45);
        }
    }
    //void Animation()
    //{
    //    birdAnimationSpeed += Time.deltaTime;
    //    if (birdAnimationSpeed > 0.15)
    //    {
    //        birdAnimationSpeed = 0;
    //        if (!retryControl)
    //        {
    //            spriteRenderer.sprite = birdSprite[birdCounter];
    //            birdCounter++;
    //            if (birdCounter == birdSprite.Length)
    //            {
    //                birdCounter--;
    //                retryControl = true;
    //            }
    //        }
    //        else
    //        {
    //            birdCounter--;
    //            spriteRenderer.sprite = birdSprite[birdCounter];
    //            if (birdCounter == 0)
    //            {
    //                birdCounter++;
    //                retryControl = false;
    //            }
    //        }
    //    }
    //}
}
