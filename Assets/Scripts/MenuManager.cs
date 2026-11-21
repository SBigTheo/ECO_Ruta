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
        SceneManager.LoadScene(nombreEscena);
    }

    [Preserve]
    public void Salir()
    {
        Application.Quit();
    }
}