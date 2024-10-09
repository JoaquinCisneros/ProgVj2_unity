using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerirYDespawnear : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float puntos = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que colisionamos es el jugador.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Accedemos al script del jugador para modificar su vida.
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            if (jugador != null)
            {
                // Reducimos la vida del jugador.
                jugador.ModificarVida(-puntos);
                Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR: " + puntos);

                // Destruimos el enemigo después de hacer daño.
                Destroy(gameObject);
            }
        }
    }
}

