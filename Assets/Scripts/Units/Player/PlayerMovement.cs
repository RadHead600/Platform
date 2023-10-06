using UnityEngine;

public class PlayerMovement : Player, IMove
{
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheckPos;

    private void FixedUpdate()
    {
        Move();

        if ((_moveJoystick.Direction.y > 0.5f || Input.GetKeyDown(KeyCode.Space)) && IsGround())
            Jump();
    }

    public void Move()
    {
        Vector2 movement = new Vector2(_moveJoystick.Direction.x * PlayerParameters.Speed, _rb.velocity.y);
        if (_rb.velocity.x < PlayerParameters.Speed)
            _rb.AddForce(movement);
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, PlayerParameters.Jump);
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircleAll(_groundCheckPos.position,
            PlayerParameters.GroundDistanceTrigger, PlayerParameters.GroundLayer).Length > 0;
    }
}
