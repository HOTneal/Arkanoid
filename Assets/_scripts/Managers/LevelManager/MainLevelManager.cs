using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelManager : MonoBehaviour
{
    #region Singltone
    private static MainLevelManager _instance;
    public static MainLevelManager Instance => _instance;

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

    [SerializeField] private LevelScriptableObjects[] m_Levels;
    private int m_QuantityLevels;

    public int currentLevel;
    
    private void Start()
    {
        if (LevelChoice.Instance != null)
            ChoiceLevel(LevelChoice.Instance.m_LevelNumber);
        else
            ChoiceLevel(1);

        m_QuantityLevels = m_Levels.Length;
    }

    private void ChoiceLevel(int levelNumber)
    {
        currentLevel = levelNumber - 1;
        SendToStartGenerateBricks(levelNumber - 1);
    }

    public void ReLoadLevel()
    {
        SendToStartGenerateBricks(currentLevel);
    }

    public void NextLevel()
    {
        currentLevel++;
        SendToStartGenerateBricks(currentLevel);
    }

    private void SendToStartGenerateBricks(int levelNumber)
    {
        if (levelNumber == m_QuantityLevels)
        {
            levelNumber = 0;
            currentLevel = 0;
        }
        BrickGenerate.Instance.StartGenerateBricks(m_Levels[levelNumber]);
    }
}
