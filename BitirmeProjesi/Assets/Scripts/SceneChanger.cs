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
        // M�zik bitince InfoDisplay metodu �a�r�lacak
        float musicLength = audioSource.clip.length;
        Invoke("InfoDisplay", musicLength);
    }

    void InfoDisplay()
    {
        // M�zik bittikten sonra bilgi metnini g�ster
        infoText.gameObject.SetActive(true);
        StartCoroutine(HideInfoText());
    }

    IEnumerator HideInfoText()
    {
        // Belirtilen s�re sonra bilgi metnini gizle
        yield return new WaitForSeconds(infoDisplayDuration);
        infoText.gameObject.SetActive(false);

        // Ard�ndan di�er sahneye ge�
        SceneManager.LoadScene(nextSceneName);
    }
}
