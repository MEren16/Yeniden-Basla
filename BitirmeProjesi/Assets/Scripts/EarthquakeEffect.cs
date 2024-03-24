using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeEffect : MonoBehaviour
{
    public float shakeDuration = 15f; // Deprem s�resi (saniye)
    public float minShakeIntensity = 0.1f; // Minimum titre�im �iddeti
    public float maxShakeIntensity = 0.5f; // Maksimum titre�im �iddeti

    private Vector3 originalPosition; // Orjinal kamera pozisyonu
    private float shakeTimer = 0f; // Deprem zamanlay�c�s�

    void Start()
    {
        // Kameran�n orijinal pozisyonunu kaydet
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Deprem zamanlay�c�s�n� g�ncelle
        if (shakeTimer > 0)
        {
            // Kameray� titret
            float shakeIntensity = Mathf.Lerp(maxShakeIntensity, minShakeIntensity, shakeTimer / shakeDuration);
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;

            // Zamanlay�c�y� azalt
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Deprem sona erdi�inde kameray� orijinal konumuna geri getir
            transform.localPosition = originalPosition;
        }
    }

    // Oyun ba�lad���nda depremi ba�latan metod
    void StartEarthquake()
    {
        // Deprem s�resini ba�lat
        shakeTimer = shakeDuration;
    }

    void OnEnable()
    {
        // Oyun ba�lad���nda depremi ba�lat
        Invoke("StartEarthquake", 10f); // 10 saniye sonra depremi ba�lat
    }
}
