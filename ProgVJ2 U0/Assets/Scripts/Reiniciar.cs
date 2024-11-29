using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{   
    [SerializeField] PerfilJugador  perfilJugador;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            perfilJugador.ReiniciarValores();
            SceneManager.LoadScene("Nivel 1");
        }
    }
}
