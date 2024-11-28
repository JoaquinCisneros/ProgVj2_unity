using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText, highScoreText;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;

    /*public void ActualizarTextoHUD(string nuevoTexto) {
        Debug.Log("Se llama: " + nuevoTexto);
        miTexto.text = nuevoTexto;
    }*/

    private void Update()
    {
        // Actualizar el texto de puntaje en cada cuadro
        currentScoreText.text = "Score: " + ScoreManager.Instance.GetCurrentScore();
        highScoreText.text = "HighScore: " + ScoreManager.Instance.GetHighScore();
    }
    public void ActualizarVidasHUD(int vidas) {
        Debug.Log("Actualizando Vidas");
        if (EstaVacioContenedor()) {
            CargarContenedor(vidas);
            return;
        }

        if (CantidadIconosVidas() > vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
    }

    private bool EstaVacioContenedor() { 
        return contenedorIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas() {
        return contenedorIconosVida.transform.childCount;
    }

    private void EliminarUltimoIcono() {
        Transform contenedor = contenedorIconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CargarContenedor(int cantidadIconos) {
        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono() { 
        Instantiate(iconoVida, contenedorIconosVida.transform);
    }
}
