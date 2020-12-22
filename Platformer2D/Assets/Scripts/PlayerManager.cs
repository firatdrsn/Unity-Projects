using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Platformer2d
{
    public class PlayerManager : MonoBehaviour
    {
        public float health;
        public GameObject deathScreen, WinnerScreen;
        Transform muzzle;
        public Transform bullet, floatingText, bloodParticle;
        public float bulletSpeed;
        public Slider slider;
        bool mouseIsNotOverUI;

        void Start()
        {
            slider.maxValue = health;
            slider.value = health;
            muzzle = transform.GetChild(1);
            print("Eger menuden acmaz isen null reference hatasi veriyor");
        }
        void Update()
        {
            mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;//eger herhangi bir ui elamanina tiklanmamis ise true tiklanmis ise false degeri donuyor ona gore ates edip etmemesi saglaniyor
            if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
            {
                ShootBullet();
            }
            Winner();
        }
        public void GetDamage(float damage)
        {
            Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
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
        public void AmIDead()
        {
            if (health <= 0)
            {
                Instantiate(bloodParticle, transform.position, Quaternion.identity);
                deathScreen.SetActive(true);
                Destroy(gameObject);
            }
        }
        void ShootBullet()
        {
            Transform tempBullet;
            tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
            DataManager.Instance.ShotBullet++;
        }
        public void Winner()
        {
            if (DataManager.Instance.EnemyKilled >= 15)
            {
                GetComponent<PlayerController>().gameObject.SetActive(false);
                WinnerScreen.SetActive(true);
            }
        }

    }
}
