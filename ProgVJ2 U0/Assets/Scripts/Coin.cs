using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int experienciaGanada; // Cantidad de experiencia que la moneda otorga al jugador.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el objeto con el que colisionamos es el jugador.
        if (collision.CompareTag("Player"))
        {
            // Accedemos al script de progresión del jugador para agregar experiencia.
            Progression progression = collision.GetComponent<Progression>();

            if (progression != null)
            {
                // Añadimos la experiencia al jugador.
                progression.GanarExperiencia(experienciaGanada);
            }

            // Destruimos el objeto moneda.
            Destroy(gameObject);
        }
    }
}
