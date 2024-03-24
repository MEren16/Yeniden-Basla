using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public Transform groundArea; // Ground alan�
    private List<Transform> prefabInstances = new List<Transform>(); // Prefab ��elerin listesi

    // Kay�t i�in veri datas�
    private struct PrefabData
    {
        public Vector3 position;
       
    }
    private List<PrefabData> prefabDataList = new List<PrefabData>(); // Prefab verilerinin listesi

    // AraMen� paneli a��ld���nda
    public void OnAraMenuOpened()
    {
        // Ground alan�ndaki prefab ��eleri bul
        foreach (Transform child in groundArea)
        {
            prefabInstances.Add(child); // Prefab ��esini listeye ekle
            prefabDataList.Add(new PrefabData { position = child.position }); // Pozisyonunu prefab veri listesine ekle
        }
    }

    // Oyun durdu�unda veya ��k�� yaparken
    private void OnApplicationQuit()
    {
        // Oyun durdu�unda veya ��k�� yaparken kaydetme i�lemi
        SaveGameProgress();
    }

    // Oyun durdu�unda veya ��k�� yaparken kaydetme i�lemi
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

    // Oyuna devam edildi�inde
    private void ContinueGame()
    {
        // �nceden kaydedilmi� prefab verilerini y�kleyebilir ve Ground alan�ndaki prefab ��elerini yeniden olu�turma
        int prefabCount = PlayerPrefs.GetInt("PrefabCount", 0);
        for (int i = 0; i < prefabCount; i++)
        {
            Vector3 prefabPosition = new Vector3(PlayerPrefs.GetFloat("PrefabPosX" + i),
                                                 PlayerPrefs.GetFloat("PrefabPosY" + i),
                                                 PlayerPrefs.GetFloat("PrefabPosZ" + i));
            
        }
    }
}
