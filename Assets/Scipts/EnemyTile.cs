using UnityEngine;

public class EnemyTile : GameTile
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent<Bullet>(out var bullet))
        {
            GameManager.Instance.GridManager.NumberOfEnemies--;
            GameManager.Instance.GridManager.SetLocationType(transform.position);

            Destroy(gameObject);
            Destroy(bullet);
        }
    }
}
