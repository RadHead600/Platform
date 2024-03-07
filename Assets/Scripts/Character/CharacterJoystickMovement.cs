using System.Collections;
using UnityEngine;

public class CharacterJoystickMovement : CharacterMovement
{
    [SerializeField] private Joystick _movementJoystick;

    private float _horizontalForce;
    private bool _isJumpAllowed;
    private bool _isAcrossPlatformAllowed;
    private float _waitingTimeForJump = 0.5f;
    private float _waitingTimeForAcrossPlatform = 0.5f;
    private const float MAX_JOYSTICK_DIRECTION_Y_FOR_JUMP = 0.5f;
    private const float MIN_JOYSTICK_DIRECTION_Y_FOR_ACROSS_PLATFORM = 0;

    void Start()
    {
        _isAcrossPlatformAllowed = true;
        _isJumpAllowed = true;
    }

    void Update()
    {
#if UNITY_WEBGL || UNITY_EDITOR
        Move(_horizontalForce);
        if (_movementJoystick.JoystickDirection.y >= MAX_JOYSTICK_DIRECTION_Y_FOR_JUMP && Grounded() && _isJumpAllowed)
        {
            _isJumpAllowed = false;
            Jump();
            StartCoroutine(StartTimerJump());
        }

        if (_movementJoystick.JoystickDirection.y < MIN_JOYSTICK_DIRECTION_Y_FOR_ACROSS_PLATFORM && _isAcrossPlatformAllowed)
        {
            _isAcrossPlatformAllowed = false;
            AcrossPlatform();
            StartCoroutine(StartTimerAcrossPlatform());
        }
#endif
    }

    private IEnumerator StartTimerJump()
    {
        yield return new WaitForSeconds(_waitingTimeForJump);
        _isJumpAllowed = true;
    }

    private IEnumerator StartTimerAcrossPlatform()
    {
        yield return new WaitForSeconds(_waitingTimeForAcrossPlatform);
        _isAcrossPlatformAllowed = true;
    }
}
