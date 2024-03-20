using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorModel : MonoBehaviour
{
    [FormerlySerializedAs("cellController")] public RoomModel roomModel; // CellController'a eri�mek i�in referans
    private void Start()
    {
        // cellController'a referans atamas� yap�l�yor
        roomModel = GameObject.FindObjectOfType<RoomModel>();


        // CellController referans� al�nm�� m� diye kontrol et
        if (roomModel == null)
        {
            Debug.LogError("CellController referans� atanmam��!");
            return; // Referans atanmam��sa, kodun devam�n� �al��t�rmaya gerek yok
        }
    }

    private void Update()
    {
        CheckEnemy();
    }

    private void CheckEnemy()
    {
        // enemyCount ve enemyGroupCount de�erlerini kontrol et
        if (roomModel.enemyCount == 0 && roomModel.enemyGroupCount == 0)
        {
            // Kap� a��ld� mesaj�n� yazd�r
            Debug.Log("Kap� a��ld�");
        }
        else
        {
            Debug.Log("Kap� a��lmad�. enemyCount: " + roomModel.enemyCount + ", enemyGroupCount: " + roomModel.enemyGroupCount);
        }
    }
}
