using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int experienciaGanada; // Cantidad de experiencia que la moneda otorga al jugador.
    private AudioSource myAudioSource;
    private Jugador jugador;

    private void OnEnable()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        if (jugador == null)
        {
            Debug.LogError("No se encontró un jugador en la escena.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Progression progression = collision.GetComponent<Progression>();
            if (progression != null)
            {
                progression.GanarExperiencia(experienciaGanada);
                ScoreManager.Instance.AddPoints(5);
            }

            // Reproducimos el sonido.
            myAudioSource.PlayOneShot(jugador.PerfilJugador.CoinSFX);

            // Desactivamos la moneda visualmente y luego la destruimos tras un breve retraso.
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, jugador.PerfilJugador.CoinSFX.length);
        }
    }
}
