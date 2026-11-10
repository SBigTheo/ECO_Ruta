using UnityEngine;

public class MovimientoPeaton : MonoBehaviour
{
    [Header("Configuración de Ruta")]
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Vector2 destinoActual;
    private bool yendoAlPuntoB = true;

    void Start()
    {
        if (puntoA == null || puntoB == null)
        {
            Debug.LogError("Faltan asignar los puntos A y B en el Inspector del peatón.");
            enabled = false;
            return;
        }

        transform.position = puntoA.position;
        destinoActual = puntoB.position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destinoActual, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, destinoActual) < 0.1f)
        {
            if (yendoAlPuntoB)
            {
                destinoActual = puntoA.position;
                yendoAlPuntoB = false;
            }
            else
            {
                destinoActual = puntoB.position;
                yendoAlPuntoB = true;
            }

            GirarHaciaDestino();
        }
    }

    void GirarHaciaDestino()
    {
        Vector2 direccion = (destinoActual - (Vector2)transform.position).normalized;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);
    }
}