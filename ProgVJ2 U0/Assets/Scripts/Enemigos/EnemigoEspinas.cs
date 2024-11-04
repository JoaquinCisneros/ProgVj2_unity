using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEspinas : Enemigo
{
    public override void Herir(IDamageable target)
    {
        target.TakeDamage(puntos);
        Debug.Log("Enemigo Espinas infligió " + puntos + " puntos de daño");
    }
}