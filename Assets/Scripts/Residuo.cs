using UnityEngine;

public class Residuo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SistemaRecoleccion sistema = other.GetComponent<SistemaRecoleccion>();

            if (sistema != null)
            {
                sistema.Recolectar();
                Destroy(gameObject);
            }
        }
    }
}