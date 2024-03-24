using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonController : MonoBehaviour
{
    public GameObject bilgiEkraný;
    public Text bilgiText;

    public void ButonaTikla()
    {
        // Butona týklandýðýnda ekraný aktif hale getir
        bilgiEkraný.SetActive(true);

        // Bilgi metnini ayarla
        bilgiText.text = " Merhaba Baþkan,\r\n\r\nÞehri yönetmek için alt kýsýmda yer alan yapýlarý, ilgili alanlara yerleþtirmeniz gerekiyor. Lütfen bu iþlemi gerçekleþtirirken bütçe kontrolünüzü de göz önünde bulundurun. Bir sonraki güne geçmek için \"End Turn\" butonunu kullanmanýz gerekiyor.\r\n\r\nTeþekkürler.";

        // Belirli bir süre sonra ekraný pasif hale getir
        Invoke("EkranKapat", 10f);
    }

    void EkranKapat()
    {
        // Ekraný pasif hale getir
        bilgiEkraný.SetActive(false);
    }
}

