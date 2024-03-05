using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementAnimation : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _legs;
    [SerializeField] private Animation _animation;

    public void MoveAnimation(float horizontal)
    {
        _animation.IsRun = horizontal != 0;
        ChangeLegsDirection(horizontal >= 0);
    }

    private void ChangeLegsDirection(bool isFlip)
    {
        foreach (var leg in _legs)
        {
            leg.flipX = isFlip;
        }
    }
}
