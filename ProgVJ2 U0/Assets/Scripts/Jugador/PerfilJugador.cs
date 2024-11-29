using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador",  menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [SerializeField]private int nivel;
    private int nivelInicial;
    public int Nivel { get => nivel; set => nivel = value; }

    [SerializeField]private int experiencia;
    private int expInicial;
    public int Experiencia { get => experiencia; set => experiencia = value; }
    [Header("Configuraciones de experiencia")]
    [SerializeField]
    [Tooltip("Cuanta xp es necesaria para el proximo nivel")]
    private int experienciaProximoNivel;
    private int experienciaProxNivelInicial;
    public int ExperienciaProximoNivel { get => experienciaProximoNivel; set => experienciaProximoNivel = value; }

    [SerializeField]
    [Tooltip("Cuanto aumenta la xp necesaria de un nivel a otro")]
    private int escalarExperiencia;
    public int EscalarExperiencia { get => escalarExperiencia; set => escalarExperiencia = value; }

    [Header("Configuraciones de movimiento")]
    [SerializeField] private float velocidad = 5f;
    public float VelocidadHorizontal { get => velocidad; set => velocidad = value; }

    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }

    [Header("Configuraciones de atributos")]
    [SerializeField] private int vidaInicial = 5;
    [SerializeField] private int vida = 5;
    public int Vida { get => vida; set => vida = value; }

    public void ReiniciarValores() {
        vida = vidaInicial;
        nivel = nivelInicial;
        experiencia = expInicial;
        experienciaProximoNivel = experienciaProxNivelInicial;
    }

    [Header("Configuracion SFX")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip collisionSFX;
    [SerializeField] private AudioClip hitSFX;
    [SerializeField] private AudioClip coinSFX;

    public AudioClip JumpSFX { get => jumpSFX; }
    public AudioClip CollisionSFX { get => collisionSFX; }
    public AudioClip HitSFX { get => hitSFX; }
    public AudioClip CoinSFX { get => coinSFX; }
}
