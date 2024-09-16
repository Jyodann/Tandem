using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Civillian : GameTile
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent<Bullet>(out var bullet))
        {
            GameManager.Instance.GridManager.SetLocationType(transform.position);

            Destroy(gameObject);
            Destroy(bullet);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
