using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected Unit unit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out unit))
        {
            GiveBonus();
        }    
    }
    
    protected abstract void GiveBonus();
}
