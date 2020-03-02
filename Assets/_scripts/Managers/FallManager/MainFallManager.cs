using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFallManager : MonoBehaviour
{
    #region Singltone
    private static MainFallManager _instance;
    public static MainFallManager Instance => _instance;

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

    [SerializeField] private float m_TimeForFall;
    private Vector2 m_DefaultPositionBall;

    private void Start()
    {
        m_DefaultPositionBall = LinkBallController.Instance.m_Ball.transform.position;
    }

    public IEnumerator StartFall()
    {
        var linkBallController = LinkBallController.Instance;
        
        linkBallController.m_Ball.DisableBall();
        MainBricksManager.Instance.m_QuantityBricksInLevel = 0;
        ClearBricks.Instance.Clear();

        yield return new WaitForSeconds(m_TimeForFall);

        MainLevelManager.Instance.ReLoadLevel();
        linkBallController.m_Ball.ReloadBall();
        linkBallController.m_Ball.transform.position = m_DefaultPositionBall;
    }
}