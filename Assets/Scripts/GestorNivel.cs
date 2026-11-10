using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorNivel : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject pantallaNivelSuperado;
    public GameObject pantallaDerrota;

    [Header("Configuración de Niveles")]
    public int indiceSiguienteNivel = 1;

    private bool nivelTerminado = false;

    void Start()
    {
        if (pantallaNivelSuperado != null) pantallaNivelSuperado.SetActive(false);
        if (pantallaDerrota != null) pantallaDerrota.SetActive(false);
    }

    public void GanoNivel()
    {
        if (nivelTerminado) return;
        nivelTerminado = true;

        if (pantallaNivelSuperado != null) pantallaNivelSuperado.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PerdioNivel()
    {
        if (nivelTerminado) return;
        nivelTerminado = true;

        if (pantallaDerrota != null) pantallaDerrota.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlSiguienteNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(indiceSiguienteNivel);
    }
}