using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class MenuManager : MonoBehaviour
{
    [Header("Nombre de la Escena a Cargar")]
    public string nombreEscena = "Tutorial";

    void Start()
    {
        if (UnityEngine.InputSystem.Accelerometer.current != null)
            UnityEngine.InputSystem.InputSystem.DisableDevice(UnityEngine.InputSystem.Accelerometer.current);
    }

    [Preserve]
    public void Jugar()
    {
        Time.timeScale = 1f;

        if (GestorTransicion.instancia != null)
        {
            GestorTransicion.instancia.CambiarEscena(nombreEscena);
        }
        else
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }

    [Preserve]
    public void Salir()
    {
        Application.Quit();
    }
}