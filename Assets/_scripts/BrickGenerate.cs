using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BrickGenerate : MonoBehaviour
{
    #region Singltone
    private static BrickGenerate _instance;
    public static BrickGenerate Instance => _instance;

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

    [SerializeField] private GameObject[] m_Bricks;
    [SerializeField] private Transform m_ZeroCell;
    private int[,] m_IndexBricks;

    public void StartGenerateBricks(LevelScriptableObjects levelParameters)
    {
        ClearBricks.Instance.Clear();
        CreateArrayFromText(levelParameters);
        VisualGenerateBricks(levelParameters);
    }

    private void CreateArrayFromText(LevelScriptableObjects levelParameters)
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Levels/{levelParameters.LevelName}");
        string[] oneLinesNumbers = textAsset.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        m_IndexBricks = new int[levelParameters.FieldWidth, levelParameters.FieldHeight];
        int count = 0;
        for (int i = 0; i < levelParameters.FieldWidth; i++)
        {
            for (int j = 0; j < levelParameters.FieldHeight; j++, count++)
                m_IndexBricks[i, j] = int.Parse(oneLinesNumbers[count]);
        }
    }

    private void VisualGenerateBricks(LevelScriptableObjects levelParameters)
    {
        for (int x = 0; x < levelParameters.FieldWidth; x++)
        {
            for (int y = 0; y < levelParameters.FieldHeight; y++)
            {
                var linkBrickManager = m_Bricks[m_IndexBricks[x, y]].GetComponent<LinkBrickManager>();
                if (linkBrickManager != null)
                    linkBrickManager.m_RandomLive = levelParameters.RandomLive;

                var cell = Instantiate(m_Bricks[m_IndexBricks[x, y]], m_ZeroCell);
                cell.transform.localPosition = new Vector2(y, x);

                if ((m_IndexBricks[x, y] != 0) && (m_IndexBricks[x, y] != 6))
                    MainBricksManager.Instance.m_QuantityBricksInLevel++;
            }
        }
    }
}
