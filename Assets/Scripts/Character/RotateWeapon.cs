using System;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] private Transform _body;

    public void WeaponRotate(ref float offset, Vector3 difference, GameObject hand)
    {
        float rotate = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        hand.transform.rotation = Quaternion.Euler(0f, 0f, rotate + offset);

        Vector3 pos = _body.transform.localScale;
        _body.transform.localScale = new Vector3(
            (difference.x < 0 ? Math.Abs(pos.x) * -1 : Math.Abs(pos.x)) * (transform.localScale.x > 0 ? -1 : 1),
            pos.y,
            pos.z
            );

        if (pos.x < 0)
        {
            offset = 0;

            if (transform.localScale.x < 0)
                offset = -180;
        }
        else
        {
            offset = -180;

            if (transform.localScale.x < 0)
                offset = 0;
        }
    }
}

