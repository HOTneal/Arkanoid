using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadText : MonoBehaviour
{
    #region Singltone
    private static ReloadText _instance;
    public static ReloadText instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion


    [SerializeField] private GameObject[] m_AllText;
    private LocalMenu m_LocalMenu;
    private Text m_Text;

    public void Reload()
    {
        for (int i = 0; i < m_AllText.Length; i++)
        {
            m_LocalMenu = m_AllText[i].GetComponent<LocalMenu>();
            m_Text = m_AllText[i].transform.GetChild(0).GetComponent<Text>();
            m_Text.text = LocalizationManager.instance.GetLocalizedValue(m_LocalMenu.m_KeyText);
        }
    }
}
