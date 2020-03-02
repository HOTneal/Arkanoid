using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBonusManager : MonoBehaviour
{
    #region Singltone
    private static MainBonusManager _instance;
    public static MainBonusManager Instance => _instance;

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

    [SerializeField] private GameObject[] m_Bonuses;
    [SerializeField] private Transform m_ParentForBonusObjs;
    private GameObject m_TypeBonusForGenerate;

    public void GenerateBonus(Transform trans, LinkBrickManager.BonusType bonusType)
    {
        BonusTypeDetermenation(bonusType);
        var Createdbonus = Instantiate(m_TypeBonusForGenerate, trans);
        Createdbonus.transform.SetParent(m_ParentForBonusObjs);
        Createdbonus.transform.position = trans.position;
        Createdbonus.GetComponent<LinkBonusManager>().bonusType = bonusType;
    }

    private void BonusTypeDetermenation(LinkBrickManager.BonusType bonus)
    {
        switch (bonus)
        {
            case LinkBrickManager.BonusType.AddBall:
                m_TypeBonusForGenerate = m_Bonuses[0];
                break;
            case LinkBrickManager.BonusType.SpeedBallDown:
                m_TypeBonusForGenerate = m_Bonuses[1];
                break;
            case LinkBrickManager.BonusType.SpeedBallUp:
                m_TypeBonusForGenerate = m_Bonuses[2];
                break;
            case LinkBrickManager.BonusType.WidthPlatform:
                m_TypeBonusForGenerate = m_Bonuses[3];
                break;
        }
    }

    public void ActiveBonus(LinkBonusManager bonus)
    {
        var bonusInstance = TypesOfBonuses.Instance;
        
        switch (bonus.bonusType)
        {
            case LinkBrickManager.BonusType.AddBall:
                bonusInstance.AddBall();
                break;
            case LinkBrickManager.BonusType.SpeedBallDown:
                StartCoroutine(bonusInstance.SpeedBallDown());
                break;
            case LinkBrickManager.BonusType.SpeedBallUp:
                StartCoroutine(bonusInstance.SpeedBallUp());
                break;
            case LinkBrickManager.BonusType.WidthPlatform:
                StartCoroutine(bonusInstance.WidthPlatform());
                break;
        }
    }
}