using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;
    private GameManager gm;
    void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Topun transformunun pozisyonunun Y’sinden büyükse gameobjecti yok et ve 25 ekle
        // Halkalar geç yok olduğu için topun ysini ekliyoruz bu da 14, 13 gibi bir rakam ideal
        if (transform.position.y + 13f >= ball.position.y)
        {
            Destroy(gameObject);
            gm.GameScore(25);
        }
    }
}
