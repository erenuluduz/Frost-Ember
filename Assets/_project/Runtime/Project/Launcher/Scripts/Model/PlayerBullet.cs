using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody2D rb;
    public float force;
    public float bulletLife;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        Vector3 direction = enemy.transform.position - transform.position; // d��man�n konumunu bulup ona ilerler
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update() // belli bir s�re sonra mermiyi kald�r�r
    {
        bulletLife += Time.deltaTime;
        if (bulletLife > 6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // d��mana de�erse mermiyi kald�r�r
        {
            Debug.Log("Enemy Collision happened");
            Destroy(gameObject);
        }
    }

}
