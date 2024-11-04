using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour
{
    [SerializeField] protected int puntos = 1;
    [SerializeField] protected float cooldownDa�o = 2f; // Tiempo de espera entre da�os
    [SerializeField] protected float iframesDuration = 1f; // Duraci�n de iframes

    private float tiempoUltimoDa�o;
    private bool puedeHacerDa�o = true; // Estado que controla si el enemigo puede hacer da�o

    protected virtual void Start()
    {
        tiempoUltimoDa�o = -cooldownDa�o; // Permite que el da�o pueda aplicarse de inmediato
    }

    // M�todo que aplica el da�o al objetivo
    public abstract void Herir(IDamageable target);

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && puedeHacerDa�o)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null && Time.time >= tiempoUltimoDa�o + cooldownDa�o)
            {
                Herir(damageable);
                tiempoUltimoDa�o = Time.time; // Actualiza el tiempo del �ltimo da�o
                puedeHacerDa�o = false; // Desactiva la posibilidad de hacer da�o inmediatamente

                // Inicia la corutina antes de desactivar el objeto
                StartCoroutine(ReiniciarDa�o());

                // Desactiva el objeto solo si es un Enemigo Volador
                if (this is EnemigoVolador)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    // Corrutina para reiniciar la posibilidad de hacer da�o despu�s de iframes
    private IEnumerator ReiniciarDa�o()
    {
        yield return new WaitForSeconds(iframesDuration);
        puedeHacerDa�o = true; // Permite al enemigo hacer da�o nuevamente
    }
}

