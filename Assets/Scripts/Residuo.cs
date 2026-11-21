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

                if (GestorSFX.instancia != null)
                {
                    GestorSFX.instancia.SonidoRecoleccion();
                }

                Destroy(gameObject);
            }
        }
    }
}