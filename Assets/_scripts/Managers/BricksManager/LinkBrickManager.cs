using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBrickManager : MonoBehaviour
{
    public enum BonusType
    {
        NoBonus,
        AddBall,
        SpeedBallDown,
        SpeedBallUp,
        WidthPlatform
    }
    
    [SerializeField] private bool m_Immortal = false;
    
    public int m_Live;
    public bool m_RandomLive = false;
    public BonusType m_ChoiceBonus = BonusType.NoBonus;
    
    private void Start()
    {
        if (m_RandomLive)
            m_Live = Random.Range(1, 3);
    }
    
    public void LinkOnBrokenBreak()
    {
        MainBricksManager.Instance.BrokenBrick(m_Live, m_ChoiceBonus, m_Immortal, this);
    }

    private void OnMouseUp()
    {
        LinkOnBrokenBreak();
    }
}
