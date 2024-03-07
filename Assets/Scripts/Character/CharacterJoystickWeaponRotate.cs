using UnityEngine;

public class CharacterJoystickWeaponRotate : MonoBehaviour
{
    [SerializeField] private Joystick _attackJoystick;
    [SerializeField] private RotateWeapon _rotateWeapon;
    [SerializeField] private CharacterWeapon _characterWeapon;

    private float _offset;

    public float Offset
    {
        get => _offset;
        set => _offset = value;
    }

    private void Update()
    {
#if UNITY_WEBGL || UNITY_EDITOR
        Vector3 difference = new Vector3(_attackJoystick.JoystickDirection.x, _attackJoystick.JoystickDirection.y);
        _rotateWeapon.WeaponRotate(ref _offset, difference, _characterWeapon.Hand);
#endif
    }
}