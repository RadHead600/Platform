using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Animation anim;

    public Animation Animation
    {
        set
        {
            anim = value;
            ChangeAnimation();
        }
    }

    private void ChangeAnimation()
    {
        animator.SetInteger("Animation", (int)anim);
    }
}

public enum Animation
{
    Idle,
    Run,
    Hit,
    Jump,
    DoubleJump
}
