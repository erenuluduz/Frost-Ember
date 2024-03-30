using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public EnemyBullet enemyBullet;
  
    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
            ObjectPooler.SetupPool(enemyBullet, 10, "EnemyBullet");
    }
}
