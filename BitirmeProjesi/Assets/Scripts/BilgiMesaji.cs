using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BilgiMesaji : MonoBehaviour
{
    public Text Mesaj;
    public AudioSource audioSource;
    public float mesajSure = 10f; // Mesaj�n ekranda kalaca�� s�re

    private bool messageShown = false; // Mesaj�n zaten g�sterilip g�sterilmedi�ini kontrol etmek i�in

    void Start()
    {
        // AudioSource bile�enini bul
        audioSource = GetComponent<AudioSource>();

        // AudioSource'un biti� olay�na abone ol
        audioSource?.AddComponent<AudioFinishedEvent>().audioFinished.AddListener(ShowMessage);
    }

    void ShowMessage()
    {
        // Mesaj daha �nce g�sterilmediyse
        if (!messageShown)
        {
            // Mesaj� g�ster
            Mesaj.text = " Say�n Ba�kan,\r\n\r\nMaalesef �ok �z�c� bir felaket ya�ad�k ve ne yaz�k ki t�m yap�lar�m�z y�k�ld�. �imdi kalan b�t�emiz ile yeniden bir �ehir kurmam�z gerekiyor. Size g�veniyoruz, bu zorlu s�re�te liderli�inizle yeniden in�a s�recini ba�ar�yla y�netece�inize inan�yoruz. ";

            // Belirtilen s�re sonra mesaj� kald�r
            StartCoroutine(KaldirMesaji());

            // Mesaj�n zaten g�sterildi�ini i�aretle
            messageShown = true;
        }
    }

    IEnumerator KaldirMesaji()
    {
        // Belirtilen s�re kadar beklet
        yield return new WaitForSeconds(mesajSure);

        // Mesaj� kapat
        Mesaj.text = "";
    }
}

// AudioSource biti� olay� i�in �zel bir s�n�f
public class AudioFinishedEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public UnityEngine.Events.UnityEvent audioFinished;

    void Start()
    {
        // AudioSource nesnesinin null olmad���ndan ve clip'in null olmad���ndan emin ol
        if (audioSource != null && audioSource.clip != null)
        {
            // AudioSource'nin biti� zaman�n� belirle
            float clipLength = audioSource.clip.length;
            StartCoroutine(WaitForAudioEnd(clipLength));
        }
    }

    // AudioSource'nin biti�ini bekleyen bir metot
    IEnumerator WaitForAudioEnd(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        audioFinished?.Invoke(); // Olay� tetikle
    }
}
