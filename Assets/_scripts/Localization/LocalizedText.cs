using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    public static LocalizedText instance;

    public string key;
    public Text text;

    
    void Start()
    {
        text = GetComponent<Text>();
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
        LocalizationManager.instance.listLocalizedText.Add(this);
    }

    public void UpdateText()
    {
        text.text = LocalizationManager.instance.GetLocalizedValue(key);
    }
    
}