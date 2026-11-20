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

            GestorNivel gestor = FindFirstObjectByType<GestorNivel>();
            if (gestor != null)
            {
                gestor.PerdioNivel();
            }
        }
    }
}