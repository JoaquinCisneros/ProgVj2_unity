using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour, IDamageable
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    private Animator animator;
    private AudioSource audioSource;

    //Eventos Jugador
    [SerializeField]
    private UnityEvent<int> OnLivesChanged;

    private void Start()
    {
        animator = GetComponent<Animator>();
        OnLivesChanged.Invoke(perfilJugador.Vida);
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damageAmount) {
        ModificarVida(-damageAmount);
        Debug.Log("Recibio daño: " + damageAmount);
        TriggerHitAnimation();
        if (audioSource != null)
        {
            audioSource.PlayOneShot(perfilJugador.HitSFX);
        }

    }

    private void TriggerHitAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isHit", true); // Activar el flag de daño
            animator.SetTrigger("Hit");
            StartCoroutine(ResetHitFlag());
        }
        else
        {
            Debug.LogWarning("Animator no asignado en el jugador.");
        }
    }

    private IEnumerator ResetHitFlag()
    {
        yield return new WaitForSeconds(0.1f); // Ajusta la duración según sea necesario
        animator.SetBool("isHit", false);
    }

    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;
        OnLivesChanged.Invoke(perfilJugador.Vida);
        //OnTextChanged.Invoke(perfilJugador.Vida.ToString());
        if (!EstasVivo()) {
            SceneManager.LoadScene("Derrota");
        }
        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }
        //Cambio a la escena de victoria
        SceneManager.LoadScene("Victoria");
        Debug.Log("GANASTE");
    }
}