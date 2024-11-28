using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{   
    [SerializeField] Jugador jugador;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            jugador.PerfilJugador.Vida = 5;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
