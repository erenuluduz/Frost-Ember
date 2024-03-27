using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

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
    
    public HealthBarScripts healthBar;

    public List<GameObject> snowBalls;
    
    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float dashSpeed;

    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth = 10;

    [SerializeField]
    private float timer = 0.2f;

    [SerializeField]
    private float dashTimer = 0;

    [SerializeField]
    private bool dashing;

    [SerializeField]
    private bool invincible;

    public Slider reloadSlider;
    public bool dashButtonClicked;
    public Button attackButtonOn;
    public Button attackButtonOff;
    public float camStartSize = 3f;
    public float camEndSize = 5f;
    public float camZoomDuration = 2f;
    private int bulletSize;

    private int emptyClickCount =0;
    
    private void Awake()
    {
        bulletSize = snowBalls.Count - 1;
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    private void Start()
    {
        currentSpeed = moveSpeed;
        dashSpeed = 20;
        
        rb = GetComponent<Rigidbody2D>();
        
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        
        mainCamera.GetComponent<Camera>().orthographicSize = camStartSize;

        
        mainCamera.GetComponent<Camera>().DOOrthoSize(camEndSize, camZoomDuration).SetEase(Ease.Linear);
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;
        
        Dashing();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (currentHealth > 0 && invincible ==false)
            {
                currentHealth--;
                healthBar.SetHealth(currentHealth);
                
                //Debug.Log("Player took --damage-- and current health ---> " + currenHealth);
                Destroy(collision.gameObject);
            }
        }

       /* if (collision.gameObject.CompareTag("HealthPotion"))
        {
            if (currentHealth > 0)
            {
                
                currentHealth++;
                healthBar.SetHealth(currentHealth);
               //Debug.Log("Player took ++HealthPotion++ and current health ---> " + currenHealth);
            }
        }
        */
    }

    public void OnClickAttack()
    {
        Debug.Log(bulletSize);
        
            if (bulletSize > 0)
            { 
                Instantiate(playerBullet, bulletSpawnPoint.position, Quaternion.identity);
                snowBalls[bulletSize].SetActive(false);
                bulletSize--;
                emptyClickCount = 0;
            }
            else if (bulletSize <= 0)
            {
                snowBalls[bulletSize].SetActive(false);

                if (emptyClickCount <= 0)
                {
                    attackButtonOn.gameObject.SetActive(false);
                    attackButtonOff.gameObject.SetActive(true);
                    StartCoroutine(BulletActive());
                    StartCoroutine(TwoSeconds());
                    StartCoroutine(SliderActive());
                    emptyClickCount++;
                }
            }
    }

    IEnumerator SliderActive()
    {
        reloadSlider.gameObject.SetActive(true);
        while (reloadSlider.value < 1f)
        {
            yield return new WaitForSeconds(0.2f);
            reloadSlider.value += 0.1f;
        }
        reloadSlider.value = 1f;
        if (reloadSlider.value == 1f)
        {
            reloadSlider.gameObject.SetActive(false);
            reloadSlider.value = 0f;
        }
    }
    IEnumerator BulletActive()
    {
        foreach (var VARIABLE in snowBalls)
        {
            if (VARIABLE.activeSelf != true)
            {
                yield return new WaitForSeconds(0.25f);
                VARIABLE.SetActive(true);
            }
        }
    }

    IEnumerator TwoSeconds()
    {
        yield return new WaitForSeconds(2);

        attackButtonOn.gameObject.SetActive(true);
        attackButtonOff.gameObject.SetActive(false);
        
        bulletSize = snowBalls.Count - 1;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
    }

    public void OnClickDash()
    {
        dashButtonClicked = true;
    }
    public void Dashing()
    {
        if (dashing)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0.2f;
                currentSpeed = moveSpeed;
                dashing = false;
                invincible = false;
            }
            
        }
        if(dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
        }
    }

    public void OnClickDashing()
    {
        if (dashTimer <= 0f && Input.GetKeyDown(KeyCode.D))
        {
            currentSpeed = dashSpeed;
            dashing = true;
            invincible = true;
            dashTimer = 1;
        }
    }

}
