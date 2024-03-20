using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceBullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
    }

   
    void Update()
    {
        
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
