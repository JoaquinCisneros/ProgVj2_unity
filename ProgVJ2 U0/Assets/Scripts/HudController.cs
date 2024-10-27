using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;

    public void ActualizarTextoHUD(string nuevoTexto) {
        Debug.Log("Se llama: " + nuevoTexto);
        miTexto.text = nuevoTexto;
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
