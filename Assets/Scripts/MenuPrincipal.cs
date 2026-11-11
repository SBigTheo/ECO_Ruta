using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    void Start()
    {
        if (UnityEngine.InputSystem.Accelerometer.current != null)
            UnityEngine.InputSystem.InputSystem.DisableDevice(UnityEngine.InputSystem.Accelerometer.current);
    }

    public void Jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}