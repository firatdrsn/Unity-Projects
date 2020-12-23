using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject ball;//top nesnesine ulasmak icin public yaptim. Boylece top nesnesinin degerlerine ulasabilirim
    Vector3 ballAndCameraDistance;//top ve kamera arasindaki mesafeyi bulmak icin tanimladim
    void Start()
    {
        ballAndCameraDistance = transform.position - ball.transform.position;//kameranin pozisyonundan topun pozisyonunu cikararak aralarindaki mesafeyi bulmus oluyorum

    }
    public void BallFind()
    {
        //ball = GameObject.Find("Ball");//top nesnesini bul
    }
    private void Update()
    {

    }
    void LateUpdate()//late update ile diğer updateler bittikten sonra calismasini sagliyoruz. Kameranin titremesi gibi problemleri cozmus oluyoruz
    {
        transform.position = ballAndCameraDistance + ball.transform.position;//kameramin poziyonuna topun poziyonunu veriyorum ama aradaki mesafeyide ekliyorum. Boylece kamera uzaktan topu takip etmis oluyor
    }
    
}
