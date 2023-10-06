﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private float _handleRange = 1;
    [SerializeField] private float _deadZone = 0;
    [SerializeField] protected RectTransform _background = null;
    [SerializeField] private RectTransform _handle = null;
    [SerializeField] private RectTransform _baseRect = null;
    [SerializeField] private Canvas _canvas;


    public float HandleRange
    {
        get { return _handleRange; }
        set { _handleRange = Mathf.Abs(value); }
    }

    public float DeadZone
    {
        get { return _deadZone; }
        set { _deadZone = Mathf.Abs(value); }
    }

    public Vector2 Direction => new Vector2(_input.x, _input.y);

    private float _defaultPivot = 0.5f;
    private float _preferableRadius = 2.0f;
    private float _magnitudeThreshold = 1.0f;
    private Camera _camera;
    private Vector2 _input = Vector2.zero;

    protected virtual void Start()
    {
        
        HandleRange = _handleRange;
        DeadZone = _deadZone;
        
        if (_canvas == null)
            Debug.LogError("The Joystick is not placed inside a _canvas");

        Vector2 center = new Vector2(_defaultPivot, _defaultPivot);
        _background.pivot = center;
        _handle.anchorMin = center;
        _handle.anchorMax = center;
        _handle.pivot = center;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        _camera = null;
        
        if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
            _camera = _canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(_camera, _background.position);
        Vector2 radius = _background.sizeDelta / _preferableRadius;
        _input = (eventData.position - position) / (radius * _canvas.scaleFactor);
        HandleInput(_input.magnitude, _input.normalized, radius, _camera);
        _handle.anchoredPosition = _input * radius * _handleRange;
    }

    protected void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > _deadZone)
        {
            if (magnitude > _magnitudeThreshold)
                _input = normalised;
        }
        else
            _input = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _background.gameObject.SetActive(false);
        _input = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        _background.gameObject.SetActive(true);
        OnDrag(eventData);
    }

    protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
        Vector2 localPoint = Vector2.zero;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _camera, out localPoint))
        {
            Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
            return localPoint - (_background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
        }
        
        return Vector2.zero;
    }
}
