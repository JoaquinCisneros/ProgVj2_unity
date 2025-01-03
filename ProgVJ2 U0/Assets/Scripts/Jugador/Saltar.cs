using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    private Jugador jugador;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;

    public BoxCollider2D groundCollider2D;
    private int saltarMask;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void Awake()
    {
        jugador = GetComponent<Jugador>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
        jugador = GetComponent<Jugador>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;

            if (miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(jugador.PerfilJugador.JumpSFX);
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * jugador.PerfilJugador.FuerzaSalto, ForceMode2D.Impulse);
            saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (groundCollider2D.IsTouchingLayers(saltarMask)) {
            puedoSaltar = true;
            saltando = false;
        }

        if (miAudioSource.isPlaying) { return; }
        miAudioSource.PlayOneShot(jugador.PerfilJugador.CollisionSFX);
    }

}