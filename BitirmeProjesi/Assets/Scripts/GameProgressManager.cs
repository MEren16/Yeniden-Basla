using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public Transform groundArea; // Ground alaný
    private List<Transform> prefabInstances = new List<Transform>(); // Prefab öðelerin listesi

    // Kayýt için veri datasý
    private struct PrefabData
    {
        public Vector3 position;
       
    }
    private List<PrefabData> prefabDataList = new List<PrefabData>(); // Prefab verilerinin listesi

    // AraMenü paneli açýldýðýnda
    public void OnAraMenuOpened()
    {
        // Ground alanýndaki prefab öðeleri bul
        foreach (Transform child in groundArea)
        {
            prefabInstances.Add(child); // Prefab öðesini listeye ekle
            prefabDataList.Add(new PrefabData { position = child.position }); // Pozisyonunu prefab veri listesine ekle
        }
    }

    // Oyun durduðunda veya çýkýþ yaparken
    private void OnApplicationQuit()
    {
        // Oyun durduðunda veya çýkýþ yaparken kaydetme iþlemi
        SaveGameProgress();
    }

    // Oyun durduðunda veya çýkýþ yaparken kaydetme iþlemi
    private void SaveGameProgress()
    {
        // Prefab verilerini bir dosyada veya PlayerPrefs'te saklama
        
        for (int i = 0; i < prefabDataList.Count; i++)
        {
            PlayerPrefs.SetFloat("PrefabPosX" + i, prefabDataList[i].position.x);
            PlayerPrefs.SetFloat("PrefabPosY" + i, prefabDataList[i].position.y);
            PlayerPrefs.SetFloat("PrefabPosZ" + i, prefabDataList[i].position.z);
        }
        PlayerPrefs.SetInt("PrefabCount", prefabDataList.Count);
        PlayerPrefs.Save();
    }

    // Oyuna devam edildiðinde
    private void ContinueGame()
    {
        // Önceden kaydedilmiþ prefab verilerini yükleyebilir ve Ground alanýndaki prefab öðelerini yeniden oluþturma
        int prefabCount = PlayerPrefs.GetInt("PrefabCount", 0);
        for (int i = 0; i < prefabCount; i++)
        {
            Vector3 prefabPosition = new Vector3(PlayerPrefs.GetFloat("PrefabPosX" + i),
                                                 PlayerPrefs.GetFloat("PrefabPosY" + i),
                                                 PlayerPrefs.GetFloat("PrefabPosZ" + i));
            
        }
    }
}
