using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float bulletLife;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");


        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
    
    private void Update()
    {
        if (force > 1)
        {
            force -= Time.deltaTime;
        }
        bulletLife += Time.deltaTime;
        if (bulletLife > 6)
        {
            ObjectPooler.EnqueueObject(this, "EnemyBullet");
        }

        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
