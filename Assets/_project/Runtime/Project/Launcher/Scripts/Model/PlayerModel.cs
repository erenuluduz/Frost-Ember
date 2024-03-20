using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class PlayerModel : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform bulletSpawnPoint;
    
    private Rigidbody2D rb;
    private Vector2 move;
    
    [SerializeField]
    public FixedJoystick joystick;
    
    [SerializeField]
    private HealthBarScripts healthBar;
    
    [SerializeField]
    private float dashSpeed = 10f;
    [SerializeField]
    private float dashDuration = 1f;
    [SerializeField]
    private float dashCooldown = 1f;
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private int currenHealth;
    [SerializeField]
    private int maxHealth = 10;
    
    [SerializeField]
    private bool isDashing;
    [SerializeField]
    private bool canDash = false;


    private void Awake()
    {
        currenHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        if (Input.GetKeyDown(KeyCode.D) && canDash)
        {
            Debug.Log("KEY PRESSED");
            IsDashed();
            //StartCoroutine(Dash());
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (currenHealth > 0)
            {
                currenHealth--;
                healthBar.SetHealth(currenHealth);
                //Debug.Log("Player took --damage-- and current health ---> " + currenHealth);
            }
        }

        if (collision.gameObject.CompareTag("HealthPotion"))
        {
            if (currenHealth > 0)
            {
                
                currenHealth++;
                healthBar.SetHealth(currenHealth);
               //Debug.Log("Player took ++HealthPotion++ and current health ---> " + currenHealth);
            }
        }
    }
    
    public void OnClickAttack()
    {
        Instantiate(playerBullet, bulletSpawnPoint.position, Quaternion.identity);

    }

    //private IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    rb.velocity = new Vector2(move.x * dashSpeed, move.y * moveSpeed * dashSpeed * Time.fixedDeltaTime);
    //    yield return new WaitForSeconds(dashDuration);
    //    isDashing = false;

    //    yield return new WaitForSeconds(dashCooldown);
    //    canDash = true;
    //}

    private void IsDashed()
    {
        canDash = true;
    }

}
