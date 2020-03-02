using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBallController : MonoBehaviour
{
    #region Singltone
    private static LinkBallController _instance;
    public static LinkBallController Instance => _instance;

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

    public BallController m_Ball;
}
