using UnityEngine;

public class BonusBox : Unit
{
    [SerializeField] private GameObject[] _bonuses;

    private void Start()
    {
        HP = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bullet bullet))
        {
            DropBonus();
        }
    }

    public void DropBonus()
    {
        GameObject dropBonus = Instantiate(_bonuses[Random.Range(0, _bonuses.Length)].gameObject, transform.position, transform.rotation);
        dropBonus.SetActive(true);
        Destroy(gameObject);  
    }
}
