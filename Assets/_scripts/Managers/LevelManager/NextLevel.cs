using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LinkNextlevel()
    {
        MainLevelManager.Instance.NextLevel();
        LinkBallController.Instance.m_Ball.ReloadBall();
        WinManager.Instance.WinPanelClose();
    }
}