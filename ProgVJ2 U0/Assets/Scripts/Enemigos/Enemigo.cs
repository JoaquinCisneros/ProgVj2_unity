using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour
{
    [SerializeField] protected int puntos = 1;

    public abstract void Herir(IDamageable target);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                Herir(damageable);
            }
        }
    }
}


