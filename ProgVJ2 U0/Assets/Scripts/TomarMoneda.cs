using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarMoneda : MonoBehaviour
{
    private Progresion progresionJugador;

    private void Awake() {
        progresionJugador = GetComponent<Progresion>();
    }
}
