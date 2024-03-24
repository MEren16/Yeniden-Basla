using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    // Gitmek istediðiniz sahnenin ismi
    public string targetSceneName;

    // Buton týklandýðýnda çaðrýlacak metod
    public void OnButtonClick()
    {
        // Oyun durumunu kaydet
        SaveGame();

        // Hedef sahneye geçiþ yap
        SceneManager.LoadScene(2);
    }

    // Oyun durumunu kaydeden metod
    private void SaveGame()
    {
        // Örneðin, oyuncunun pozisyonunu kaydedebiliriz
        Vector3 playerPosition = transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        // Diðer oyun durumu verilerini de kaydedebilirsiniz
    }
}

