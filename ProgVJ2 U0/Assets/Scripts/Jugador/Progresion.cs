using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public int nivel;
    public int experiencia;
    public int experienciaProximoNivel;
    public int escalarExperiencia;

    public void GanarExperiencia(int nuevaExperiencia) {
        experiencia += nuevaExperiencia;
        if (experiencia >= experienciaProximoNivel) {
            SubirNivel();
        }
    }

    public void SubirNivel() {
        nivel++;
        experiencia -= experienciaProximoNivel;
        experienciaProximoNivel += escalarExperiencia;
    }
}
