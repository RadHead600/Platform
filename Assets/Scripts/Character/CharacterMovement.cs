using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterMovementParameters _characterMovementParameters;
    [SerializeField] private CharacterMovementAnimation _characterMovementAnimation;
    [SerializeField] private Rigidbody2D _rigidBody;

    private bool _isIgnorePlatform;
    private const float IGNORE_TIME_PLATFORM_DEFAULT = 0.5f;
    private const int MIN_COUNT_GROUNDED_COLLIDERS = 1;
    private const float GROUND_RADIUS = 0.5f;
    private const int PLAYER_LAYER = 10;
    private const int PLATFORM_LAYER = 18;

    void Start()
    {
    }

    public virtual void AcrossPlatform()
    {
        IgnorePlatform();
        Invoke("IgnorePlatform", IGNORE_TIME_PLATFORM_DEFAULT);
    }

    private void IgnorePlatform()
    {
        _isIgnorePlatform = !_isIgnorePlatform;
        Physics2D.IgnoreLayerCollision(PLAYER_LAYER, PLATFORM_LAYER, _isIgnorePlatform);
    }

    public virtual void Move(float horizontalForce)
    {
        Vector2 movement = new Vector3(horizontalForce * _characterMovementParameters.Speed * Time.fixedDeltaTime, 0.0f);
        _rigidBody.AddForce(movement);
        _characterMovementAnimation.MoveAnimation(horizontalForce);
    }

    public virtual void Jump()
    {
        _rigidBody.AddForce(transform.up * _characterMovementParameters.Jump, ForceMode2D.Impulse);
    }

    public bool Grounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GROUND_RADIUS, _characterMovementParameters.BlockStay);
        return colliders.Length >= MIN_COUNT_GROUNDED_COLLIDERS;
    }

}
