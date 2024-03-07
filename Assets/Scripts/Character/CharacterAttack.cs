using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public bool isAttackEnd { get; private set; }

    private void Start()
    {
        isAttackEnd = true;
    }

    public IEnumerator Attack(Vector3 difference, float offset, CharacterWeapon weapon)
    {
        float rotate = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        isAttackEnd = false;

        if (weapon.Weapon.BulletInMagazine <= weapon.Weapon.WeaponParameters.MinBulletInMagazine)
        {
            weapon.Weapon.BulletInMagazine = weapon.Weapon.WeaponParameters.BulletInmagazine;
            yield return new WaitForSeconds(weapon.Weapon.WeaponParameters.RechargeTime);
            isAttackEnd = true;
            yield break;
        }

        weapon.Hand.transform.rotation = Quaternion.Euler(0f, 0f, rotate + offset + Random.Range(weapon.Weapon.WeaponParameters.Spread * -1, weapon.Weapon.WeaponParameters.Spread));
        weapon.Weapon.Attack(difference);
        yield return new WaitForSeconds(weapon.Weapon.WeaponParameters.Delay);
        isAttackEnd = true;
    }
}
