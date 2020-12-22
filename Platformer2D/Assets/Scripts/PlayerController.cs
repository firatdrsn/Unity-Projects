using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2d
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D playerRB;
        Animator playerAnimator;
        [SerializeField] float moveSpeed = 4f;
        [SerializeField] float jumpSpeed, jumpFrequency = 1f, nextJumpTime;
        bool facingRight = true;
        bool isGrounded = false;
        [SerializeField] Transform groundCheckPosition;
        [SerializeField] float groundCheckRadius;
        [SerializeField] LayerMask groundCheckLayer;


        void Start()
        {
            isGrounded = false;
            playerRB = GetComponent<Rigidbody2D>();
            playerAnimator = GetComponent<Animator>();
        }
        void FixedUpdate()
        {
            HorizontalMove();//yurumesi icin gereken fonksiyon
            if (Input.GetAxisRaw("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))//yukari tuslari basildiginda ve karakter yere temas ediyorsa jump methodunu calistirir
            {                                                   //bir sonraki ziplama zamani, oyun basladigindan beri gecen surden kucukse jump methodu calisacak
                nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;//Bir sonraki ziplama zamani icin su an ki zamani yani zipladigimiz zamani + bir sonraki ziplama icin gereken sureyi ekleyip bu degiskene atiyoruz. Boylece if ile kontrol ederken bu zaman dolmadan if icine girilmemis olacak
                Jump();
            }
        }
        void Update()
        {
            OnGroundCheck();//Zemine temasi kontrol ediyoruz
            if (playerRB.velocity.x < 0 && facingRight)//playerin hizi eksili yani yonu sola dogru ve yuzu saga ise flipface methodu ile playeri ceviriyoruz
            {
                FlipFace();
            }
            else if (playerRB.velocity.x > 0 && !facingRight)//playerin yonu saga dogru ve yuzu sola bakiyorsa flip face ile yuzunun yonunu degistiriyoruz
            {
                FlipFace();
            }
            

        }
        void HorizontalMove()
        {
            playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
            playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));//animator icinde tanimli olan playerSpeed degiskenine karakterin x duzlemindeki degerinin mutlak degerini gonderiyor. Buna gore karakter ya durma yani idle ya da run animasyonunu calistiriyor
        }
        void FlipFace()
        {
            facingRight = !facingRight;
            Vector3 tempLocalscale = transform.localScale;
            tempLocalscale.x *= -1;
            transform.localScale = tempLocalscale;
        }
        void Jump()
        {
            playerRB.AddForce(new Vector2(0, jumpSpeed));
        }
        void OnGroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
            playerAnimator.SetBool("isGroundedAnim", isGrounded);
        }

    }
}