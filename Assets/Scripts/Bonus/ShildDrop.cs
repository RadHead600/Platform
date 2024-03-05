using UnityEngine;

public class ShildDrop : Bonus
{
    [SerializeField] private int _armorAdd;

    protected override void GiveBonus()
    {
        if (unit is Character)
        {
            ((Character)unit).AddShild(_armorAdd);
            Destroy(gameObject);
        }
    }

}
