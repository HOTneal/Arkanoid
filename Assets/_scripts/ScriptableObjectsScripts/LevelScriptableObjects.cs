using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateNewLevel")]
public class LevelScriptableObjects : ScriptableObject
{
    [SerializeField] private string m_LevelName;
    [SerializeField] private int m_FieldWidth;
    [SerializeField] private int m_FieldHeight;
    [SerializeField] private bool m_RandomLive;

    public string LevelName { get { return m_LevelName; } }
    public int FieldWidth { get { return m_FieldWidth; } }
    public int FieldHeight { get { return m_FieldHeight; } }
    public bool RandomLive { get { return m_RandomLive; } }
}
