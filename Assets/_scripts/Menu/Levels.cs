using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Levels : MonoBehaviour
{
    [SerializeField] private Text m_Text;

    private void Start()
    {
        m_Text = transform.GetChild(0).GetComponent<Text>();
        m_Text.text = LocalizationManager.instance.GetLocalizedValue(m_Text.text);
    }
}
