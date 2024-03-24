using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeEffect : MonoBehaviour
{
    public float shakeDuration = 15f; // Deprem süresi (saniye)
    public float minShakeIntensity = 0.1f; // Minimum titreþim þiddeti
    public float maxShakeIntensity = 0.5f; // Maksimum titreþim þiddeti

    private Vector3 originalPosition; // Orjinal kamera pozisyonu
    private float shakeTimer = 0f; // Deprem zamanlayýcýsý

    void Start()
    {
        // Kameranýn orijinal pozisyonunu kaydet
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Deprem zamanlayýcýsýný güncelle
        if (shakeTimer > 0)
        {
            // Kamerayý titret
            float shakeIntensity = Mathf.Lerp(maxShakeIntensity, minShakeIntensity, shakeTimer / shakeDuration);
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;

            // Zamanlayýcýyý azalt
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Deprem sona erdiðinde kamerayý orijinal konumuna geri getir
            transform.localPosition = originalPosition;
        }
    }

    // Oyun baþladýðýnda depremi baþlatan metod
    void StartEarthquake()
    {
        // Deprem süresini baþlat
        shakeTimer = shakeDuration;
    }

    void OnEnable()
    {
        // Oyun baþladýðýnda depremi baþlat
        Invoke("StartEarthquake", 10f); // 10 saniye sonra depremi baþlat
    }
}
