using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;

    public float health;
    public float maxHealth = 10;
    private void Awake()
    {
        health = maxHealth;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if(health > 0)
            {
                health--;
                Debug.Log("Player took damage");
            }
            
        }
    }
}
