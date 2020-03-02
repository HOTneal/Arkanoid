using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector2 m_MousePosition;
    private Camera m_CameraMain;
    private Transform m_PlatformTransform;
    
    private void Awake()
    {
        m_CameraMain = Camera.main;
        m_PlatformTransform = transform;
    }

    private void OnMouseDrag()
    {
        m_MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        m_MousePosition = m_CameraMain.ScreenToWorldPoint(m_MousePosition);
        m_PlatformTransform.position = new Vector2(Mathf.Clamp(m_MousePosition.x, -10.9f, 10.9f), m_PlatformTransform.position.y);
    }
}