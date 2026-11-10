using UnityEngine;

public class CentroReciclaje : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SistemaRecoleccion sistema = other.GetComponent<SistemaRecoleccion>();

            if (sistema != null && sistema.TieneTodosLosResiduos())
            {
                GestorNivel gestor = FindObjectOfType<GestorNivel>();
                if (gestor != null)
                {
                    gestor.GanoNivel();
                }
            }
        }
    }
}