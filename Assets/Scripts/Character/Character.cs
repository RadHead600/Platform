using UnityEngine;

public class Character : Unit
{
    [SerializeField] private Shild _shild;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private EndGameUI _endGameCanvas;
    [SerializeField] private CharacterStatsUI _characterStatUI;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public const float IMPULS_UP_DEFAULT = 10.0f;
    public const float IMPULS_RIGHT_DEFAULT = 4.0f;

    private void Awake()
    {
        Time.timeScale = 1;
        _characterStatUI.ChangeText(_characterStatUI.HpText, HP.ToString());
        _characterStatUI.ChangeText(_characterStatUI.ArmorText, _shild.HP.ToString());
    }

    private void Start()
    {
    }

    public override int AddHealth(int amount)
    {
        HP += amount;
        _characterStatUI.ChangeText(_characterStatUI.HpText, HP.ToString());
        return HP;
    }
    public override int ReceiveDamage(int damage)
    {
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.AddForce(transform.up * IMPULS_UP_DEFAULT, ForceMode2D.Impulse);
        _rigidbody2D.AddForce(transform.right * IMPULS_RIGHT_DEFAULT, ForceMode2D.Impulse);
        HP -= damage;
        _characterStatUI.ChangeText(_characterStatUI.HpText, HP.ToString());
        if (HP <= MinHp)
            Die();

        return HP;
    }

    public override void Die()
    {
        _endGameCanvas.LoseCanvas();
    }

    public void AddShild(int addArmor)
    {
        _shild.gameObject.SetActive(true);
        _shild.AddArmor(addArmor);
        _characterStatUI.ChangeText(_characterStatUI.ArmorText, _shild.HP.ToString());
    }
}
