using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transitionAnimator;

    [Header("Configuración de Escenas")]
    public string nombreEscenaTutorial = "Tutorial";

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();

        if (UnityEngine.InputSystem.Accelerometer.current != null)
            UnityEngine.InputSystem.InputSystem.DisableDevice(UnityEngine.InputSystem.Accelerometer.current);
    }

    [Preserve]
    public void LoadNextScene()
    {
        StartCoroutine(SceneLoad(nombreEscenaTutorial));
    }

    public IEnumerator SceneLoad(string sceneName)
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
            yield return new WaitForSeconds(1f);
        }

        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("StartTransition");
            yield return new WaitForSeconds(1f);
        }

        SceneManager.LoadScene(sceneIndex);
    }

    [Preserve]
    public void Salir()
    {
        Application.Quit();
    }
}