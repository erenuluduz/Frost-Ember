using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EnemyBullet enemyBulletPrefab;

    void Awake()
    {
        ClearPreviousPools();
        SetupPool();
    }

    void ClearPreviousPools()
    {
        // Eski havuz girdilerini temizle
        if (ObjectPooler.poolDictionary.ContainsKey("EnemyBullet"))
        {
            ObjectPooler.poolDictionary.Remove("EnemyBullet");
        }

        if (ObjectPooler.poolLookup.ContainsKey("EnemyBullet"))
        {
            ObjectPooler.poolLookup.Remove("EnemyBullet");
        }
    }

    void SetupPool()
    {
        // Yeni havuzu kur
        ObjectPooler.SetupPool(enemyBulletPrefab, 10, "EnemyBullet");
    }
}
