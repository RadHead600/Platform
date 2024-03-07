using UnityEngine;

public class CharacterJoystickAttack : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Joystick _attackJoystick;
    [SerializeField] private CharacterWeapon _characterWeapon;
    [SerializeField] private CharacterStatsUI _characterStatUI;
    [SerializeField] private CharacterJoystickWeaponRotate _weaponRotate;
    [SerializeField] private CharacterAttack _characterAttack;

    private Coroutine _attackCoroutine;
    private Vector3 _difference;

    private void Start()
    {
        _characterWeapon.Weapon.BulletInMagazine = _characterWeapon.Weapon.WeaponParameters.BulletInmagazine;
        _characterStatUI.ChangeText(_characterStatUI.BulletsText, _characterWeapon.Weapon.BulletInMagazine.ToString());
    }

    private void Update()
    {
#if UNITY_WEBGL || UNITY_EDITOR
        if (_attackJoystick.JoystickDirection.x != 0 || _attackJoystick.JoystickDirection.y != 0)
        {
            _difference = new Vector3(_attackJoystick.JoystickDirection.x, _attackJoystick.JoystickDirection.y);
            if (_characterAttack.isAttackEnd)
            {
                _attackCoroutine = StartCoroutine(_characterAttack.Attack(_difference, _weaponRotate.Offset, _characterWeapon));
                _characterStatUI.ChangeText(_characterStatUI.BulletsText, _characterWeapon.Weapon.BulletInMagazine.ToString());
            }
        }
#endif
    }
}
