using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用LineRender绘制扇形
/// </summary>
public class DrawFanShape : MonoBehaviour
{
    public int angle;
    public float radius;

    [SerializeField]
    private LineRenderer lineRenderer;

    public void Draw()
    {
        lineRenderer.positionCount = angle + 2;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(angle + 1, Vector3.zero);
        for (int i = 0; i < angle; i++)
        {
            lineRenderer.SetPosition(i + 1,
                Quaternion.Euler(0, -angle / 2 + i, 0) * Vector3.forward * radius);
        }
    }

    private void OnEnable()
    {
        Draw();
    }
}
