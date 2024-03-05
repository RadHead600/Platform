using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _joystickSpeed;
    [SerializeField] private float _jump;
    [SerializeField] private LayerMask _block_Stay;
    [SerializeField] private CharacterMovementAnimation _characterMovementAnimation;

    private Rigidbody2D _rigidBody;
    private bool _isIgnorePlatform;
    private const float IGNORE_TIME_PLATFORM_DEFAULT = 0.5f;
    private float _waitingTimeForJoystickJump = 0.4f;
    private float _timerJoystickJump;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Grounded();
#if UNITY_WEBGL && !UNITY_EDITOR
        if (_timerJoystickJump > 0)
        {
            _timerJoystickJump -= Time.deltaTime;
        }
        JoystickMove();
        if (Joystick.Instance.JoystickDirection.y >= 0.5f && Grounded() && _timerJoystickJump <= 0)
        {
            Jump();
            _timerJoystickJump = _waitingTimeForJoystickJump;
        }
        if (Joystick.Instance.JoystickDirection.y < 0)
        {
            AcrossPlatform();
        }
        
#elif UNITY_2020_1_OR_NEWER
        Move();
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AcrossPlatform();
        }
#endif
    }

    private void AcrossPlatform()
    {
        IgnorePlatform();
        Invoke("IgnorePlatform", IGNORE_TIME_PLATFORM_DEFAULT);
    }

    private void IgnorePlatform()
    {
        _isIgnorePlatform = !_isIgnorePlatform;
        Physics2D.IgnoreLayerCollision(10, 18, _isIgnorePlatform);
    }

    private void JoystickMove()
    {
        if (Joystick.Instance == null)
            return;
        if (Joystick.Instance.JoystickDirection.y != 0)
        {
            _rigidBody.velocity = new Vector2(Joystick.Instance.JoystickDirection.x * _joystickSpeed, _rigidBody.velocity.y);
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector3(horizontal * _speed * Time.fixedDeltaTime, 0.0f);
        _rigidBody.AddForce(movement);
        _characterMovementAnimation.MoveAnimation(horizontal);
    }

    public void Jump()
    {
        _rigidBody.AddForce(transform.up * _jump, ForceMode2D.Impulse);
    }

    public bool Grounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .3F, _block_Stay);
        return colliders.Length > 0.8;
    }

}
