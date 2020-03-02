using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] private bool m_IsAutoActivateBall = false;
    [SerializeField] private bool m_IsAutoDestoryBall = false;
    [SerializeField] private bool m_IsBonusBall;
    [SerializeField] private bool m_IsBallFollowOfPaltform;
    [SerializeField] private float m_TimeForDestoryBall;
    [SerializeField] private float m_Radius = 1;
    [SerializeField] private float m_OffsetYAbovePlatform;
    [SerializeField] private AudioSource m_AudioSource;
    
    public PlatformController platform;
    public float speed = 1;
    
    private bool m_IsMove;
    private Vector2 m_TargetPoint;
    private Vector2 m_CurrentDirection, m_NextDirection;
    
    private RaycastHit2D m_Hit;
    private bool m_IsBallAlive = true;
    private Transform m_BallTransform;
    
    private void Awake()
    {
        m_BallTransform = transform;
    }

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

        if (m_IsAutoActivateBall)
            ActivateBall();
        
        if (m_IsAutoDestoryBall)
            StartCoroutine(AutoDestroyBall());
    }

    private void Update()
    {
        if (!m_IsBallAlive)
            return;

        if (m_IsBallFollowOfPaltform)
        {
            FollowOfPlatform();
            
            if (Input.GetKeyDown(KeyCode.Space))
                ActivateBall();
        }
        
        if (!m_IsMove) 
            return;

        CheckNextPosition();
        BallMove();
        
        if (Vector2.Distance(m_BallTransform.position, m_TargetPoint) <= Constants.DISTANCE_HIT)
            BallHit();
    }

    private void BallHit()
    {
        var hitTransform = m_Hit.transform;

        switch (hitTransform.tag)
        {
            case Constants.TAG_BRICK:
                hitTransform.GetComponent<LinkBrickManager>().LinkOnBrokenBreak();
                break;
            case Constants.TAG_FALLZONE:
                if (m_IsBonusBall != true)
                    hitTransform.GetComponent<LinkFallManager>().LinkToStartFall();
                else
                    Destroy(gameObject);
                break;
            default:
                m_AudioSource.Play();
                break;
        }
        
        m_NextDirection = Vector2.Reflect(m_CurrentDirection, m_Hit.normal); 
        m_CurrentDirection = m_NextDirection;
        CheckNextPosition();
    }

    private void BallMove()
    {
        m_BallTransform.position = Vector2.MoveTowards(m_BallTransform.position, m_TargetPoint, Time.deltaTime * speed);
    }

    private void BallStartMove()
    {
        var random = new Random();
        var sideValues = new[] {-1, 1};
        
        int randomSideDirection = sideValues[random.Next(sideValues.Length)];
        m_CurrentDirection = new Vector2(randomSideDirection, 1);
    }

    private void CheckNextPosition()
    {
        m_Hit = Physics2D.Raycast(m_BallTransform.position, m_CurrentDirection);  
        m_TargetPoint = (m_Hit.point - (m_CurrentDirection.normalized * m_Radius));
    }

    private void ActivateBall()
    {
        m_IsMove = true;
        m_IsBallFollowOfPaltform = false;
        BallStartMove();
    }

    public void ReloadBall()
    {
        m_IsBallAlive = true;
        m_IsBallFollowOfPaltform = true;
    }

    public void DisableBall()
    {
        m_IsBallAlive = false;
        m_IsMove = false;
    }

    private void FollowOfPlatform()
    {
        m_BallTransform.position = platform.transform.position + (Vector3.up * m_OffsetYAbovePlatform);
    }

    private IEnumerator AutoDestroyBall()
    {
        yield return new WaitForSeconds(m_TimeForDestoryBall);
        Destroy(gameObject);
    }
}
