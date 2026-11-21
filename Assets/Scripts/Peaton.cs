using UnityEngine;

public class Peaton : MonoBehaviour
{
    private bool yaChocado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (yaChocado) return;

        if (other.CompareTag("Player"))
        {
            yaChocado = true;

            if (GestorSFX.instancia != null)
            {
                GestorSFX.instancia.SonidoAtropello();
            }

            GestorNivel gestor = FindFirstObjectByType<GestorNivel>();
            if (gestor != null)
            {
                gestor.PerdioNivel();
            }
        }
    }
}