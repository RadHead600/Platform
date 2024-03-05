public class Shild : Unit
{
    public void AddArmor(int quantity)
    {
        HP += quantity;
    }

    public override int ReceiveDamage(int quantity)
    {
        HP -= quantity;
        if (HP <= 0)
            Die();
        return HP;
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
