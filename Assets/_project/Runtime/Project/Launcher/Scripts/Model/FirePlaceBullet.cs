using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceBullet : MonoBehaviour
{
    public float speed;
    public float destroyDelay = 5f; // Örnek olarak 3 saniye sonra yok edelim

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;

        // Belirli bir süre sonra yok etme iþlemi için Invoke() kullanýyoruz
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