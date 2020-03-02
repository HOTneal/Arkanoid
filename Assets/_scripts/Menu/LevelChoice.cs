using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoice : MonoBehaviour
{
    #region Singltone
    private static LevelChoice _instance;
    public static LevelChoice Instance => _instance;

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


    public int m_LevelNumber;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
