using UnityEngine;

public class StandartBullets : Bullet
{
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, Speed * Time.deltaTime);
    }
}
