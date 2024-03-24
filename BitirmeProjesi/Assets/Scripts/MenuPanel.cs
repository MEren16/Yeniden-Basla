using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuPanel; // Ara menü paneli

    public void OpenMenuPanel()
    {
        // Ara menü panelini aktifleþtir
        menuPanel.SetActive(true);
    }
}
