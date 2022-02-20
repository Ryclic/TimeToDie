using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenuController : MonoBehaviour
{

    public GameObject generalPanel;

    public TextMeshProUGUI generalText;

    public GameObject keybindsPanel;
    public TextMeshProUGUI keybindsText;
    public GameObject othersPanel;
    public TextMeshProUGUI othersText;
    void Start()
    {
        generalText.faceColor = new Color32(255,255,255,255);
        hideAllUI();
        
    }


    public void OpenGeneral()
    {
        hideAllUI();
        generalPanel.SetActive(true);
        generalText.faceColor = new Color32(255,255,255,255);

    }

    public void OpenKeybinds()
    {
        hideAllUI();
        keybindsPanel.SetActive(true);
        keybindsText.faceColor = new Color32(255,255,255,255);
        
    }

    public void OpenOther()
    {
        hideAllUI();
        othersPanel.SetActive(true);
        othersText.faceColor = new Color32(255,255,255,255);
    }

    void hideAllUI()
    {
        generalPanel.SetActive(false);
        keybindsPanel.SetActive(false);
        othersPanel.SetActive(false);

        generalText.faceColor = new Color32(130,130,130,255);
        keybindsText.faceColor = new Color32(130,130,130,255);
        othersText.faceColor = new Color32(130,130,130,255);
    }
}
