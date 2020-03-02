using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkWinManager : MonoBehaviour
{
    public void LinkWin()
    {
        WinManager.Instance.Win();
    }
}
