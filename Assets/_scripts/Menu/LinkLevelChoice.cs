using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LinkLevelChoice : MonoBehaviour
{
    [SerializeField] private int m_LevelNumber;

    public void GoToLevel()
    {
        LevelChoice.Instance.m_LevelNumber = m_LevelNumber;
        SceneManager.LoadScene("GameScene");
    }
}
