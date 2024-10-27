using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador",  menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [SerializeField]private int nivel;
    public int Nivel { get => nivel; set => nivel = value; }

    [SerializeField]private int experiencia;
    public int Experiencia { get => experiencia; set => experiencia = value; }
    [Header("Configuraciones de experiencia")]
    [SerializeField]
    [Tooltip("Cuanta xp es necesaria para el proximo nivel")]
    private int experienciaProximoNivel;
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
    [SerializeField] private int vida = 5;
    public int Vida { get => vida; set => vida = value; }

    [Header("Configuracion SFX")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip collisionSFX;

    public AudioClip JumpSFX { get => jumpSFX; }
    public AudioClip CollisionSFX { get => collisionSFX; }
}
