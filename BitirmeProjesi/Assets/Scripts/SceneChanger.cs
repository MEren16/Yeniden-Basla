using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public AudioSource audioSource;
    public string nextSceneName;
    public Text infoText;
    public float infoDisplayDuration = 10f;

    void Start()
    {
        // Müzik bitince InfoDisplay metodu çaðrýlacak
        float musicLength = audioSource.clip.length;
        Invoke("InfoDisplay", musicLength);
    }

    void InfoDisplay()
    {
        // Müzik bittikten sonra bilgi metnini göster
        infoText.gameObject.SetActive(true);
        StartCoroutine(HideInfoText());
    }

    IEnumerator HideInfoText()
    {
        // Belirtilen süre sonra bilgi metnini gizle
        yield return new WaitForSeconds(infoDisplayDuration);
        infoText.gameObject.SetActive(false);

        // Ardýndan diðer sahneye geç
        SceneManager.LoadScene(nextSceneName);
    }
}
