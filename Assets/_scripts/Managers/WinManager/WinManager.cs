using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    #region Singltone
    private static WinManager _instance;
    public static WinManager Instance => _instance;

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

    [SerializeField] private GameObject m_WinPanel;

    public void Win()
    {
        m_WinPanel.SetActive(true);
        LinkBallController.Instance.m_Ball.DisableBall();
    }

    public void WinPanelClose()
    {
        m_WinPanel.SetActive(false);
    }
}