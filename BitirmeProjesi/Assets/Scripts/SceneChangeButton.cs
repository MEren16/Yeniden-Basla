using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    // Gitmek istedi�iniz sahnenin ismi
    public string targetSceneName;

    // Buton t�kland���nda �a�r�lacak metod
    public void OnButtonClick()
    {
        // Oyun durumunu kaydet
        SaveGame();

        // Hedef sahneye ge�i� yap
        SceneManager.LoadScene(2);
    }

    // Oyun durumunu kaydeden metod
    private void SaveGame()
    {
        // �rne�in, oyuncunun pozisyonunu kaydedebiliriz
        Vector3 playerPosition = transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        // Di�er oyun durumu verilerini de kaydedebilirsiniz
    }
}

