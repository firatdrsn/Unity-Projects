using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer2d
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private float damage;
        float groundWidthEnd;
        float groundWidthStart;
        bool colliderBusy = false;
        [SerializeField] Slider slider;
        [SerializeField] Rigidbody2D enemyRB;
        [SerializeField] float enemySpeed;
        bool enemyPosition = true;
        void Start()
        {
            enemyRB = GetComponent<Rigidbody2D>();
            slider.maxValue = health;
            slider.value = health;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player" && !colliderBusy)//Eger objeme carpan objenin tagi player ise o player icinde bulunun get damage methodunu cagir ve damage degiskenini parametre olarak gonder
            {                             //colliderBusy booleani ile carpan playerda birden fazla collider var ise bir kez islem yapmasini sagliyoruz
                                          //bunun icin degisken false ise ifin icine giriyor ve bu degiskeni true yapiyor ondan sonra gelen colliderlar ifin icine girmiyor taa ki player triggerdan cikana kadar
                                          //bu yonteme flag yontemi deniyor
                colliderBusy = true;
                collision.GetComponent<PlayerManager>().GetDamage(damage);
                triggerForce(collision);
            }
            else if (collision.tag == "Bullet")
            {
                GetDamage(collision.GetComponent<BulletManager>().bulletDamage);
                Destroy(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")//player tagina sahip obje triggerdan yani carptigi nesneden uzaklasirsa colliderBusy degiskenini tekrar false yapiyoruz
            {
                colliderBusy = false;
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            colliderBusy = false;
            if (collision.tag == "Ground")
            {
                groundWidthStart = collision.transform.position.x;
                groundWidthEnd = collision.GetComponent<BoxCollider2D>().size.x;
                EnemyMove(groundWidthStart, groundWidthEnd);
            }
            if (collision.tag == "Player")
            {
                //collision.GetComponent<PlayerManager>().GetDamage(damage);
                triggerForce(collision);
            }
        }

        void triggerForce(Collider2D collision)
        {
            if (collision.transform.position.y >= transform.position.y && transform.position.x >= collision.GetComponent<PlayerController>().transform.position.x)
            {
                collision.GetComponent<Transform>().position -= new Vector3(2f, 0, 0);
            }
            else if (collision.transform.position.y >= transform.position.y && transform.position.x < collision.GetComponent<PlayerController>().transform.position.x)
            {
                collision.GetComponent<Transform>().position += new Vector3(2f, 0, 0);
            }
            //if (collision.transform.position.y >= transform.position.y && collision.GetComponent<PlayerController>().facingRight)
            //{
            //    collision.GetComponent<Transform>().position -= new Vector3(2f, 0, 0);
            //}
            //else if (collision.transform.position.y >= transform.position.y && !collision.GetComponent<PlayerController>().facingRight)
            //{
            //    collision.GetComponent<Transform>().position += new Vector3(2f, 0, 0);
            //}

            //if (collision.GetComponent<Rigidbody2D>().velocity.x >= 0 && collision.GetComponent<PlayerController>().facingRight)
            //{
            //    collision.GetComponent<Transform>().position -= new Vector3(2f, 0, 0);
            //}
            //else if (collision.GetComponent<Rigidbody2D>().velocity.x <= 0 && !collision.GetComponent<PlayerController>().facingRight)
            //{
            //    collision.GetComponent<Transform>().position += new Vector3(2f, 0, 0);
            //}

            if (collision.GetComponent<Rigidbody2D>().velocity.x >= 0 && transform.position.x >= collision.GetComponent<PlayerController>().transform.position.x)
            {
                collision.GetComponent<Transform>().position -= new Vector3(2f, 0, 0);
            }
            else if (collision.GetComponent<Rigidbody2D>().velocity.x <= 0 && transform.position.x < collision.GetComponent<PlayerController>().transform.position.x)
            {
                collision.GetComponent<Transform>().position += new Vector3(2f, 0, 0);
            }
        }
        public void GetDamage(float damage)
        {
            if (health >= 0)
            {
                health = health - damage;
            }
            else
            {
                health = 0;
            }
            slider.value = health;
            AmIDead();
        }
        void AmIDead()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
                DataManager.Instance.EnemyKilled++;
            }
        }
        public void DeadSpaceKill()
        {
            Destroy(gameObject);
        }
        void EnemyMove(float widthStart, float widthEnd)
        {
            if (Mathf.Abs(transform.position.x) <= Mathf.Abs(widthEnd - 1f) + Mathf.Abs(widthStart - 0.3f) && enemyPosition)
            {
                enemyRB.velocity = new Vector2(enemySpeed, 0);
            }
            else
            {
                enemyPosition = false;
            }
            if (Mathf.Abs(transform.position.x) >= Mathf.Abs(widthStart + 0.25f) && !enemyPosition)
            {
                enemyRB.velocity = new Vector2(-enemySpeed, 0);
            }
            else
            {
                enemyPosition = true;
            }
        }
    }

}