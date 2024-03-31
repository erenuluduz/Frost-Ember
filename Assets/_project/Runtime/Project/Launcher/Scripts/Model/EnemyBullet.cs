using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float bulletLife;

    public void Initialize() //mermi objesini pooldan �a��rmaya yard�mc� olur
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
    
    private void Update()
    {
        bulletLife += Time.deltaTime; // belli bir s�re sonra bullet objesini poola geri al�r
        if (bulletLife > 6)
        {
            ObjectPooler.EnqueueObject(this, "EnemyBullet");
            bulletLife = 0;
        }
    }
}
