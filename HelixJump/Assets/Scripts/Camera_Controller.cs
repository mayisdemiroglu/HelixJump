using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public Transform ball;
    private Vector3 offset;
    public float smoothSpeed;
    void Start()
    {
        // Kameranın pozisyonundan topun pozisyonunu çıkarıp offset değişkenine aktarıyoruz.
        offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Lerp metodunu burada iki nokta arasına geçiş efekti olarak kullanıyoruz.
        Vector3 newPos = Vector3.Lerp(transform.position, offset + ball.position, smoothSpeed);

        //Bizim transform positiona yeni oluşturduğumuz newposu eşitliyoruz.
        transform.position = newPos;
    }
}
