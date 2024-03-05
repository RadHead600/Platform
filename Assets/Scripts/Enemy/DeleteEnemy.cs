using UnityEngine;

public class DeleteEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.TryGetComponent(out Unit unit) ||  collision.TryGetComponent(out Bonus bonus)))
        {
            if (unit is Character)
            {
                return;
            }

            Destroy(collision.gameObject);
        }
    }
}
