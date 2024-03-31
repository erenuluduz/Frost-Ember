using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceBullet : MonoBehaviour
{
    public float speed;
    public float destroyDelay = 5f; // �rnek olarak 3 saniye sonra yok edelim

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;

        // Belirli bir s�re sonra yok etme i�lemi i�in Invoke() kullan�yoruz
        Invoke("DestroyBullet", destroyDelay);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision happened");
            Destroy(gameObject);
        }
    }
}