using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _joystickBG;
    [SerializeField] private Vector2 _joystickDirection;
    [SerializeField] private float _maxJoystickRadius = 3;

    private Vector2 _joystickTouchPos;
    private Vector2 _joystickOriginalPos;
    private float _joystickRadius;

    public Vector2 JoystickDirection => _joystickDirection;
    public static Joystick Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            throw new Exception();
        }
        Instance = this;
    }

    void Start()
    {
        _joystickOriginalPos = _joystickBG.transform.position;
        _joystickRadius = _joystickBG.GetComponent<RectTransform>().sizeDelta.y / _maxJoystickRadius;
    }

    public void PointerDown()
    {
        _joystick.transform.position = Input.mousePosition;
        _joystickBG.transform.position = Input.mousePosition;
        _joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        _joystickDirection = (dragPos - _joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, _joystickTouchPos);

        if (joystickDist < _joystickRadius)
        {
            ChangeJoystickPosition(joystickDist);
        }
        else
        {
            ChangeJoystickPosition(_joystickRadius);
        }
    }

    private void ChangeJoystickPosition(float distance)
    {
        _joystick.transform.position = _joystickTouchPos + _joystickDirection * distance;
    }

    public void PointerUp()
    {
        _joystickDirection = Vector2.zero;
        _joystick.transform.position = _joystickOriginalPos;
        _joystickBG.transform.position = _joystickOriginalPos;
    }
}