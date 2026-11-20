using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transitionAnimator;
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        if (UnityEngine.InputSystem.Accelerometer.current != null)
            UnityEngine.InputSystem.InputSystem.DisableDevice(UnityEngine.InputSystem.Accelerometer.current);
    }

    public void LoadNesxtSccene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
       StartCoroutine(SceneLoad(nextSceneIndex));
    }

    public IEnumerator SceneLoad( int sceneIndex) 
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
    public void Salir()
    {
        Application.Quit();
    }
}