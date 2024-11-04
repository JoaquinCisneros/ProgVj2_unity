using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour
{
    [SerializeField] protected int puntos = 1;
    [SerializeField] protected float cooldownDaño = 2f; // Tiempo de espera entre daños
    [SerializeField] protected float iframesDuration = 1f; // Duración de iframes

    private float tiempoUltimoDaño;
    private bool puedeHacerDaño = true; // Estado que controla si el enemigo puede hacer daño

    protected virtual void Start()
    {
        tiempoUltimoDaño = -cooldownDaño; // Permite que el daño pueda aplicarse de inmediato
    }

    // Método que aplica el daño al objetivo
    public abstract void Herir(IDamageable target);

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && puedeHacerDaño)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null && Time.time >= tiempoUltimoDaño + cooldownDaño)
            {
                Herir(damageable);
                tiempoUltimoDaño = Time.time; // Actualiza el tiempo del último daño
                puedeHacerDaño = false; // Desactiva la posibilidad de hacer daño inmediatamente

                // Inicia la corutina antes de desactivar el objeto
                StartCoroutine(ReiniciarDaño());

                // Desactiva el objeto solo si es un Enemigo Volador
                if (this is EnemigoVolador)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    // Corrutina para reiniciar la posibilidad de hacer daño después de iframes
    private IEnumerator ReiniciarDaño()
    {
        yield return new WaitForSeconds(iframesDuration);
        puedeHacerDaño = true; // Permite al enemigo hacer daño nuevamente
    }
}

