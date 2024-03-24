using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BilgiMesaji : MonoBehaviour
{
    public Text Mesaj;
    public AudioSource audioSource;
    public float mesajSure = 10f; // Mesajýn ekranda kalacaðý süre

    private bool messageShown = false; // Mesajýn zaten gösterilip gösterilmediðini kontrol etmek için

    void Start()
    {
        // AudioSource bileþenini bul
        audioSource = GetComponent<AudioSource>();

        // AudioSource'un bitiþ olayýna abone ol
        audioSource?.AddComponent<AudioFinishedEvent>().audioFinished.AddListener(ShowMessage);
    }

    void ShowMessage()
    {
        // Mesaj daha önce gösterilmediyse
        if (!messageShown)
        {
            // Mesajý göster
            Mesaj.text = " Sayýn Baþkan,\r\n\r\nMaalesef çok üzücü bir felaket yaþadýk ve ne yazýk ki tüm yapýlarýmýz yýkýldý. Þimdi kalan bütçemiz ile yeniden bir þehir kurmamýz gerekiyor. Size güveniyoruz, bu zorlu süreçte liderliðinizle yeniden inþa sürecini baþarýyla yöneteceðinize inanýyoruz. ";

            // Belirtilen süre sonra mesajý kaldýr
            StartCoroutine(KaldirMesaji());

            // Mesajýn zaten gösterildiðini iþaretle
            messageShown = true;
        }
    }

    IEnumerator KaldirMesaji()
    {
        // Belirtilen süre kadar beklet
        yield return new WaitForSeconds(mesajSure);

        // Mesajý kapat
        Mesaj.text = "";
    }
}

// AudioSource bitiþ olayý için özel bir sýnýf
public class AudioFinishedEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public UnityEngine.Events.UnityEvent audioFinished;

    void Start()
    {
        // AudioSource nesnesinin null olmadýðýndan ve clip'in null olmadýðýndan emin ol
        if (audioSource != null && audioSource.clip != null)
        {
            // AudioSource'nin bitiþ zamanýný belirle
            float clipLength = audioSource.clip.length;
            StartCoroutine(WaitForAudioEnd(clipLength));
        }
    }

    // AudioSource'nin bitiþini bekleyen bir metot
    IEnumerator WaitForAudioEnd(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        audioFinished?.Invoke(); // Olayý tetikle
    }
}
