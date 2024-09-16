using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenTile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent<Bullet>(out var bullet))
        {

            Destroy(bullet);
        }
    }
}
