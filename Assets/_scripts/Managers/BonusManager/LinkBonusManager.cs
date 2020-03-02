using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBonusManager : MonoBehaviour
{
    [SerializeField] private float m_SpeedBonus;
    private Transform m_BonusTransform;
    
    public LinkBrickManager.BonusType bonusType;

    private void Awake()
    {
        m_BonusTransform = transform;
    }

    private void Update()
    {
        BonusMoveDown();
        RaycastFromBonus();
    }

    private void BonusMoveDown()
    {
        m_BonusTransform.position = new Vector3(m_BonusTransform.position.x, m_BonusTransform.position.y - m_SpeedBonus * Time.deltaTime, m_BonusTransform.position.z);
    }

    private void RaycastFromBonus()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_BonusTransform.position, Vector2.down, 0.3f);

        if (hit.collider == null)
            return;
        
        if (hit.transform.CompareTag(Constants.TAG_PLATFORM))
        {
            MainBonusManager.Instance.ActiveBonus(this);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}