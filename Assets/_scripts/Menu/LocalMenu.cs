using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalMenu : MonoBehaviour
{
    [SerializeField] private Text m_Text;
    public string m_KeyText;

    private void Start()
    {
        m_Text = transform.GetChild(0).GetComponent<Text>();
        m_KeyText = m_Text.text;
        m_Text.text = LocalizationManager.instance.GetLocalizedValue(m_KeyText);
    }
}
