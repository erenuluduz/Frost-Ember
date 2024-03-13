using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Tilemap tilemap;

    public float enemyGroupCount;
    public float enemyCount;

    [SerializeField]private List<GameObject> enemyList = new List<GameObject>();

    private void Awake()
    {
        enemyGroupCount = Random.Range(2, 4);
        SpawnEnemies();
    }


    private void Update()
    {
        if (IsAllEnemiesDead())
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        GameObject listedEnemy;

        if (enemyGroupCount != 0)
        {
            enemyCount = Random.Range(4, 7);

            Vector3Int randomTilePosition;
            Vector3 spawnPosition;

            for (int i = 0; i < enemyCount; i++)
            {
                randomTilePosition = GetRandomPosition();
                spawnPosition = tilemap.GetCellCenterWorld(randomTilePosition);

                listedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                enemyList.Add(listedEnemy);
            }
            enemyGroupCount --;
        }
    }
    private bool IsAllEnemiesDead()
    {
        // Liste i�indeki t�m d��manlar� kontrol et
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemyList[i];
            if (enemy == null) // E�er bir d��man �ld�yse listeden kald�r
            {
                enemyList.RemoveAt(i);
            }
        }

        // E�er hi�bir d��man hayatta de�ilse true d�n
        return enemyList.Count == 0;
    }


    private Vector3Int GetRandomPosition()
    {
        BoundsInt bounds = tilemap.cellBounds;                                                      //tilemap'in s�n�r geni�li�ini verir
        Vector3Int randomTilePosition = new Vector3Int(Random.Range(bounds.x, bounds.xMax),         //tile map'in x eksenindeki minimum ve maksimum b�y�kl��� aras�ndan rastgele bir konum verir
                                                       Random.Range(bounds.y, bounds.yMax), 0);     // ayn� i�lemi y i�in yapar ve bunu pozisyon belirleme de�i�keni olan vector3'e atar.
        return randomTilePosition;
    }

    
}
