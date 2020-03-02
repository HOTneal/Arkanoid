using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLanguage : MonoBehaviour
{
    [SerializeField] private string m_Language;

    public void SetLanguage()
    {
        LocalizationManager.instance.SetLanguage(m_Language);
        ReloadText.instance.Reload();
    }
}
