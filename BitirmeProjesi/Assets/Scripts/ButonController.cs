using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonController : MonoBehaviour
{
    public GameObject bilgiEkran�;
    public Text bilgiText;

    public void ButonaTikla()
    {
        // Butona t�kland���nda ekran� aktif hale getir
        bilgiEkran�.SetActive(true);

        // Bilgi metnini ayarla
        bilgiText.text = " Merhaba Ba�kan,\r\n\r\n�ehri y�netmek i�in alt k�s�mda yer alan yap�lar�, ilgili alanlara yerle�tirmeniz gerekiyor. L�tfen bu i�lemi ger�ekle�tirirken b�t�e kontrol�n�z� de g�z �n�nde bulundurun. Bir sonraki g�ne ge�mek i�in \"End Turn\" butonunu kullanman�z gerekiyor.\r\n\r\nTe�ekk�rler.";

        // Belirli bir s�re sonra ekran� pasif hale getir
        Invoke("EkranKapat", 10f);
    }

    void EkranKapat()
    {
        // Ekran� pasif hale getir
        bilgiEkran�.SetActive(false);
    }
}

