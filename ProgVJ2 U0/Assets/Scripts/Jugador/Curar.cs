using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            if (jugador.PerfilJugador.Vida < 5) {
                jugador.ModificarVida(puntos);
            }
            Debug.Log(" PUNTOS DE DA�O REALIZADOS AL JUGADOR " + puntos);
        }
    }
}