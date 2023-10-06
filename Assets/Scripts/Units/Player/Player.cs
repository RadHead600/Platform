using UnityEngine;

public class Player : Unit
{
    [SerializeField] private AttackController _attackController;

    protected PlayerParameters PlayerParameters;

    protected override void Awake()
    {
        base.Awake();
        PlayerParameters = (PlayerParameters)Parameters;
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _attackController.Attack();
    }

}
