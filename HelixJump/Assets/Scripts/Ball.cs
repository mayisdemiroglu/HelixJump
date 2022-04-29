using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    public GameManager gm;
   

    void Start()
    {

    }
    void Update()
    {
        
    }
   
    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.up * jumpForce;
        //rb.AddForce(Vector3.up * jumpForce);

        //Splash prefabin rotasyonunu ve topun kendi rotasyonunu veriyoruz
        // Bıraktığı iz biraz havada kaldığı için new Vector3(0f, -0.2f, 0f) bu kısmı ekliyoruz
        GameObject splash = Instantiate(splashPrefab, transform.position, transform.rotation); //+ new Vector3(0f, -0.2f, 0f), transform.rotation);
        //Splashin konumu bunun transformunun setparenti(parent ata) = çarptığımız objenin transformuna
        //Çarptığı yerde iz bırakması için
        splash.transform.SetParent(other.gameObject.transform);

        //Çarptığı objenin metaryal ismini alıcak bizim oluşturduğumuz metaryalin name değişkenine aktaracak
        //Daha sonra bunları if blokları içinde kontrol edicez.
        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

        //Material name ile çalışırken düzgün çalışabilmesi için yanına (Instance) ifadesini eklememiz gerekir
        /*if(materialName == "Safe Color (Instance)")
        {
            //Puan alacak
        }*/
        if(materialName == "Unsafe Color (Instance)")
        {
            //bölüm tekrar başlayacak
            
                gm.RestartGame();
        }
        else if(materialName == "Last Ring (Instance)")
        {
            //bir sonraki bölüme geçecek
            Debug.Log("Next Level");
        }
 
    }
}
