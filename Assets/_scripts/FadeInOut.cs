using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    #region Singltone
    private static FadeInOut _instance;
    public static FadeInOut Instance => _instance;

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

    [SerializeField] private GameObject m_DarkBg;
    private CanvasGroup m_AlphaDarkBg;
    [SerializeField] private float m_SpeedFade;
    public enum ModeFadeInOut
    {
        FadeIn = 1,
        FadeOut = 2,
        Inactions = 3
    }
    public ModeFadeInOut m_ModeFade = ModeFadeInOut.Inactions;

    private void Start()
    {
        m_AlphaDarkBg = m_DarkBg.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (m_ModeFade == ModeFadeInOut.FadeIn)
            FadeIn();

        if (m_ModeFade == ModeFadeInOut.FadeOut)
            FadeOut();
    }

    private void FadeIn()
    {
        m_DarkBg.SetActive(true);

        if (m_AlphaDarkBg.alpha != 1)
            m_AlphaDarkBg.alpha += Time.deltaTime * m_SpeedFade;
        else
            m_ModeFade = ModeFadeInOut.Inactions;
    }

    private void FadeOut()
    {
        if (m_AlphaDarkBg.alpha != 0)
            m_AlphaDarkBg.alpha -= Time.deltaTime * m_SpeedFade;
        else
        {
            m_DarkBg.SetActive(false);
            m_ModeFade = ModeFadeInOut.Inactions;
        }
    }
}
