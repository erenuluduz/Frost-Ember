using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    public int currenHealth;
    public int maxHealth = 10;
    public HealthBarScripts healthBar;
    private void Awake()
    {
        currenHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
            if (currenHealth > 0)
            {
                currenHealth--;
                healthBar.SetHealth(currenHealth);
                Debug.Log("Player took --damage-- and current health ---> " + currenHealth);
            }
        }

        if (collision.gameObject.tag == "HealthPotion")
        {
            if (currenHealth > 0)
            {
                
                currenHealth++;
                healthBar.SetHealth(currenHealth);
                Debug.Log("Player took ++HealthPotion++ and current health ---> " + currenHealth);
            }
        }
    }
}
