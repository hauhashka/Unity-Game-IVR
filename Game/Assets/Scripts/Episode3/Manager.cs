using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    [SerializeField] RectTransform _transform;
    private void Update()
    {

    }

    void ReturnCursor()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, _transform.position);
        Mouse.current.WarpCursorPosition(screenPoint);
    }
}
