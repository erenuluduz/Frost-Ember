using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyScript enemyPrefab;

    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        ObjectPooler.SetupPool(enemyPrefab, 10, "Enemy");
    }
}
