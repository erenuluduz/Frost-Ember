using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using _project.Runtime.Core.Singleton;
using _project.Runtime.Project.UI.Scripts.View;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class PlayerModel : SingletonBehaviour<PlayerModel>
{
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float timer = 0.2f;

    public Animator animator;
    private bool invincible;
    public float camStartSize = 3f;
    public float camEndSize = 5f;
    public float camZoomDuration = 2f;

    private void Awake()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    private void Start()
    {
        currentSpeed = moveSpeed;
        dashSpeed = 20;

        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.GetComponent<Camera>().orthographicSize = camStartSize;
        mainCamera.GetComponent<Camera>().DOOrthoSize(camEndSize, camZoomDuration).SetEase(Ease.Linear);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (currentHealth > 0 && invincible == false)
            {
                currentHealth--;
                HealthBarScripts.Instance.SetHealth(currentHealth);

                //Debug.Log("Player took --damage-- and current health ---> " + currenHealth);
                Destroy(collision.gameObject);
            }
        }
    }

    /*public void  Dashing()
    {
        if (dashing)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0)
            {
                timer = 0.2f;
                currentSpeed = moveSpeed;
                GameScreenView.Instance.dashing = false;
                invincible = false;
                StartCoroutine(GameScreenView.Instance.DashButtonActive());
                Debug.Log("corotine çalıştı");
            }
        }*/
}
