using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorNivel : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject pantallaNivelSuperado;
    public GameObject pantallaDerrota;
    public GameObject panelPausa;

    [Header("Configuración de Niveles")]
    public int indiceSiguienteNivel = 1;

    private bool nivelTerminado = false;
    private bool estaPausado = false;

    private ControladorCamion camion;

    void Start()
    {
        if (pantallaNivelSuperado != null) pantallaNivelSuperado.SetActive(false);
        if (pantallaDerrota != null) pantallaDerrota.SetActive(false);
        if (panelPausa != null) panelPausa.SetActive(false);

        camion = FindObjectOfType<ControladorCamion>();
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

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void AlternarPausa()
    {
        if (nivelTerminado) return;

        estaPausado = !estaPausado;

        if (estaPausado)
        {
            Time.timeScale = 0f;
            if (panelPausa != null) panelPausa.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            if (panelPausa != null) panelPausa.SetActive(false);

            // Recalibrar al reanudar
            if (camion != null)
            {
                camion.Calibrar();
            }
        }
    }
}