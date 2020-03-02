using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypesOfBonuses : MonoBehaviour
{
    #region Singltone
    private static TypesOfBonuses _instance;
    public static TypesOfBonuses Instance => _instance;

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

    [SerializeField] private GameObject m_Platform;
    [SerializeField] private BallController m_BallController;
    [SerializeField] private Transform m_ParentObject;

    [Header("AddBall")]
    [SerializeField] private GameObject m_BallBig;

    [Header("WidthPlatform")]
    [SerializeField] private float m_WidhtPlatform;
    [SerializeField] private float m_TimeEndBonus;
    
    private Vector2 m_DefaultSizeOfPlatform;
    [Header("SpeedBallDown")]
    private float m_DefaultSpeedBall;

    private void Start()
    {
        m_DefaultSizeOfPlatform = m_Platform.transform.localScale;
        m_DefaultSpeedBall = m_BallController.speed;
    }

    public void AddBall()
    {
        var bigBall = Instantiate(m_BallBig, new Vector2(m_Platform.transform.position.x, m_Platform.transform.position.y + 1.5f), Quaternion.identity);
        bigBall.transform.SetParent(m_ParentObject);
    }

    public IEnumerator SpeedBallDown()
    {
        m_BallController.speed -= 5.0f;
        yield return new WaitForSeconds(m_TimeEndBonus);
        m_BallController.speed = m_DefaultSpeedBall;
    }

    public IEnumerator SpeedBallUp()
    {
        m_BallController.speed += 5.0f;
        yield return new WaitForSeconds(m_TimeEndBonus);
        m_BallController.speed = m_DefaultSpeedBall;
    }

    public IEnumerator WidthPlatform()
    {
        m_Platform.transform.localScale = new Vector2(m_Platform.transform.localScale.x + m_WidhtPlatform, m_DefaultSizeOfPlatform.y);
        yield return new WaitForSeconds(m_TimeEndBonus);
        m_Platform.transform.localScale = m_DefaultSizeOfPlatform;
    }
}
