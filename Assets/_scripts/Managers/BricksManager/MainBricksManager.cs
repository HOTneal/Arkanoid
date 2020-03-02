using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBricksManager : MonoBehaviour
{
    #region Singltone
    private static MainBricksManager _instance;
    public static MainBricksManager Instance => _instance;

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

    public int m_QuantityBricksInLevel;
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_BrokenSound;
    [SerializeField] AudioClip m_HitSound;

    public void BrokenBrick(int live, LinkBrickManager.BonusType bonus, bool immortal, LinkBrickManager objFromLink)
    {
        if (immortal == false)
        {
            live--;
            if (live == 0)
            {
                if (bonus != LinkBrickManager.BonusType.NoBonus)
                    MainBonusManager.Instance.GenerateBonus(objFromLink.transform, bonus);

                m_AudioSource.PlayOneShot(m_BrokenSound);

                m_QuantityBricksInLevel--;
                if (m_QuantityBricksInLevel == 0)
                    WinManager.Instance.Win();

                Destroy(objFromLink.gameObject);
            }
            else
            {
                m_AudioSource.PlayOneShot(m_HitSound);
                objFromLink.m_Live = live;
            }
        }
    }
}
