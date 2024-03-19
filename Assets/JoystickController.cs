using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class JoystickController : MonoBehaviour
{
    public FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    public int currenHealth;
    public int maxHealth = 10;
    public HealthBarScripts healthBar;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash = false;


    private void Awake()
    {
        currenHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        if (Input.GetKeyDown(KeyCode.D) && canDash)
        {
            Debug.Log("KEY PRESSED");
            IsDashed();
            //StartCoroutine(Dash());
        }

    }
    private void FixedUpdate()
    {
        
       
        if (canDash)
        {
            rb.MovePosition(rb.position + move * moveSpeed * dashSpeed * Time.fixedDeltaTime);
            //canDash = false;
        }
        else
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (currenHealth > 0)
            {
                currenHealth--;
                healthBar.SetHealth(currenHealth);
                //bug.Log("Player took --damage-- and current health ---> " + currenHealth);
            }
        }

        if (collision.gameObject.tag == "HealthPotion")
        {
            if (currenHealth > 0)
            {
                
                currenHealth++;
                healthBar.SetHealth(currenHealth);
               //ebug.Log("Player took ++HealthPotion++ and current health ---> " + currenHealth);
            }
        }
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
