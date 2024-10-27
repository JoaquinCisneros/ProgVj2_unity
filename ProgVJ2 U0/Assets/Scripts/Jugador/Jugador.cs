using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    //Eventos Jugador
    [SerializeField]
    private UnityEvent<int> OnLivesChanged;
    //[SerializeField]
   // private UnityEvent<string> OnTextChanged;

    private void Start()
    {
        OnLivesChanged.Invoke(perfilJugador.Vida);
        //OnTextChanged.Invoke(perfilJugador.Vida.ToString());
    }

    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;
        OnLivesChanged.Invoke(perfilJugador.Vida);
        //OnTextChanged.Invoke(perfilJugador.Vida.ToString());
        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("GANASTE");
    }
}