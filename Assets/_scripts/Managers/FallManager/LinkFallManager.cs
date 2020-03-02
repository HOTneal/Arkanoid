using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkFallManager : MonoBehaviour
{
    public void LinkToStartFall()
    {
        StartCoroutine(MainFallManager.Instance.StartFall());
    }
}