using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public GameObject menuPanel; // Ara men� paneli

    public void OpenMenuPanel()
    {
        // Ara men� panelini aktifle�tir
        menuPanel.SetActive(true);
    }
}
