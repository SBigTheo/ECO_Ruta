using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorCamion : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidadMaxima = 5f;

    [Header("Sensibilidad y Calibración")]
    [Range(0.1f, 3f)]
    public float sensibilidad = 1f;
    public float anguloMaximoInclinacion = 30f;

    [Header("Límites de Pantalla (Opcional)")]
    public bool usarLimitesDePantalla = false;
    public float limiteX = 8f;
    public float limiteY = 4.5f;

    [Header("Rotación del Sprite")]
    public float velocidadRotacion = 10f;

    private Vector3 aceleracionNeutra;
    private bool calibrado = false;

    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (UnityEngine.InputSystem.Accelerometer.current != null)
            InputSystem.EnableDevice(UnityEngine.InputSystem.Accelerometer.current);

        Calibrar();
    }

    public void Calibrar()
    {
        if (UnityEngine.InputSystem.Accelerometer.current != null)
        {
            aceleracionNeutra = UnityEngine.InputSystem.Accelerometer.current.acceleration.ReadValue();
            calibrado = true;
            Debug.Log("Calibración exitosa");
        }
    }

    void Update()
    {
        if (!calibrado || UnityEngine.InputSystem.Accelerometer.current == null) return;

        Vector3 aceleracionActual = UnityEngine.InputSystem.Accelerometer.current.acceleration.ReadValue();

        Vector3 diferencia = aceleracionActual - aceleracionNeutra;

        float inputX = diferencia.x;
        float inputY = diferencia.y;

        inputX = Mathf.Clamp(inputX / (anguloMaximoInclinacion / 90f), -1f, 1f) * sensibilidad;
        inputY = Mathf.Clamp(inputY / (anguloMaximoInclinacion / 90f), -1f, 1f) * sensibilidad;

        direccionMovimiento = new Vector2(inputX, inputY);

        if (direccionMovimiento.magnitude > 1f)
        {
            direccionMovimiento.Normalize();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direccionMovimiento * velocidadMaxima;

        if (direccionMovimiento.sqrMagnitude > 0.01f)
        {
            float angulo = Mathf.Atan2(direccionMovimiento.y, direccionMovimiento.x) * Mathf.Rad2Deg;

            Quaternion rotacionObjetivo = Quaternion.Euler(0f, 0f, angulo);

            rb.MoveRotation(Quaternion.Lerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.fixedDeltaTime));
        }
    }

    void LateUpdate()
    {
        if (usarLimitesDePantalla)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -limiteX, limiteX);
            pos.y = Mathf.Clamp(pos.y, -limiteY, limiteY);
            transform.position = pos;
        }
    }
}