
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBricks : MonoBehaviour
{

    #region Singltone
    private static ClearBricks _instance;
    public static ClearBricks Instance => _instance;

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

    [SerializeField] private GameObject m_ObjectForClear;

    public void Clear()
    {
        MainBricksManager.Instance.m_QuantityBricksInLevel = 0;

        for (int i = 0; i < m_ObjectForClear.transform.childCount; i++)
        {
            Destroy(m_ObjectForClear.transform.GetChild(i).gameObject);
        }
    }
}