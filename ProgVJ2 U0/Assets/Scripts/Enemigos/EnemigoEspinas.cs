using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEspinas : Enemigo
{
    public override void Herir(IDamageable target)
    {
        target.TakeDamage(puntos);
        Debug.Log("Enemigo Espinas infligi� " + puntos + " puntos de da�o");
    }
}