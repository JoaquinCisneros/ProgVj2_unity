using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : Enemigo
{

    public override void Herir(IDamageable target)
    {
        target.TakeDamage(puntos);
        Debug.Log("Enemigo Volador infligió " + puntos + " puntos de daño al jugador.");

        // Desactiva el objeto para despawnearlo y reutilizarlo
        gameObject.SetActive(false);
    }
}

