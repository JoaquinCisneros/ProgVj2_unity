using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    private Jugador jugador;

    private void Awake()
    {
        jugador = GetComponent<Jugador>();
    }
    public void GanarExperiencia(int nuevaExperiencia) {
        jugador.PerfilJugador.Experiencia += nuevaExperiencia;
        if (jugador.PerfilJugador.Experiencia >= jugador.PerfilJugador.ExperienciaProximoNivel) {
            SubirNivel();
        }
    }

    public void SubirNivel() {
        jugador.PerfilJugador.Nivel++;
        jugador.PerfilJugador.Experiencia -= jugador.PerfilJugador.ExperienciaProximoNivel;
        jugador.PerfilJugador.ExperienciaProximoNivel += jugador.PerfilJugador.EscalarExperiencia;
        Debug.Log("Subio de nivel");
    }
}
