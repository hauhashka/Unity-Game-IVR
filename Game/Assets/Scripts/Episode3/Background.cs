using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Background : MonoBehaviour
{
    [SerializeField] RectTransform _transform;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void PointerEnters()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, _transform.position);
        Mouse.current.WarpCursorPosition(screenPoint);
    }
}
