using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Jugador jugador;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator animator;
    private SpriteRenderer miSprite;
    private BoxCollider2D miCollider2D;

    public BoxCollider2D groundCollider2D;

    //Saltar y caer

    private int saltarMask;
    public Transform groundCheck;
    public float groundCheckRadius;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void Awake()
    {
        jugador = GetComponent<Jugador>();
        
    }
    private void OnEnable()
    {
        jugador = GetComponent<Jugador>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<BoxCollider2D>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = velocidadX < 0f;
        animator.SetInteger("Velocidad", velocidadX);

        animator.SetBool("EnAire", !EnContactoConPlataforma());
        if (miRigidbody2D.velocity.y > 0.5)
        {
            animator.SetBool("isFalling", false);
        }
        HandleFallingAnimation();
    }

    private void HandleFallingAnimation()
    {
        // Si no está en el suelo y la velocidad en Y es negativa, está cayendo.
        //bool isFalling = !isGrounded && miRigidbody2D.velocity.y < 0;
        if (miRigidbody2D.velocity.y < -0.5)
        {
            // Actualiza el parámetro del Animator.
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * jugador.PerfilJugador.VelocidadHorizontal);
    }

    private bool EnContactoConPlataforma()
    {
        return groundCollider2D.IsTouchingLayers(saltarMask);
    }
}