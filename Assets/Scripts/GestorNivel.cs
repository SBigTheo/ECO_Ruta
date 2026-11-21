using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorNivel : MonoBehaviour
{
    [Header("Referencias UI")]
    public GameObject pantallaNivelSuperado;
    public GameObject pantallaDerrota;
    public GameObject panelPausa;

    [Header("Configuración de Niveles")]
    public string nombreSiguienteNivel = "Nivel2";
    public string nombreMenu = "MenuPrincipal";

    private bool nivelTerminado = false;
    private bool estaPausado = false;

    private ControladorCamion camion;

    void Start()
    {
        if (pantallaNivelSuperado != null) pantallaNivelSuperado.SetActive(false);
        if (pantallaDerrota != null) pantallaDerrota.SetActive(false);
        if (panelPausa != null) panelPausa.SetActive(false);

        camion = FindFirstObjectByType<ControladorCamion>();
    }

    public void GanoNivel()
    {
        if (nivelTerminado) return;
        nivelTerminado = true;

        if (GestorSFX.instancia != null)
        {
            GestorSFX.instancia.SonidoVictoria();
        }

        if (pantallaNivelSuperado != null) pantallaNivelSuperado.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PerdioNivel()
    {
        if (nivelTerminado) return;
        nivelTerminado = true;

        if (GestorSFX.instancia != null)
        {
            GestorSFX.instancia.SonidoDerrota();
        }

        if (pantallaDerrota != null) pantallaDerrota.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        string escenaActual = SceneManager.GetActiveScene().name;

        if (GestorTransicion.instancia != null)
            GestorTransicion.instancia.CambiarEscena(escenaActual);
        else
            SceneManager.LoadScene(escenaActual);
    }

    public void IrAlSiguienteNivel()
    {
        Time.timeScale = 1f;

        if (GestorTransicion.instancia != null)
            GestorTransicion.instancia.CambiarEscena(nombreSiguienteNivel);
        else
            SceneManager.LoadScene(nombreSiguienteNivel);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;

        if (GestorTransicion.instancia != null)
            GestorTransicion.instancia.CambiarEscena(nombreMenu);
        else
            SceneManager.LoadScene(nombreMenu);
    }

    public void AlternarPausa()
    {
        if (nivelTerminado) return;

        estaPausado = !estaPausado;

        if (estaPausado)
        {
            Time.timeScale = 0f;
            if (panelPausa != null) panelPausa.SetActive(true);

            if (GestorAudio.instancia != null)
                GestorAudio.instancia.PausarMusica();
        }
        else
        {
            Time.timeScale = 1f;
            if (panelPausa != null) panelPausa.SetActive(false);

            if (camion != null)
            {
                camion.Calibrar();
            }

            if (GestorAudio.instancia != null)
                GestorAudio.instancia.ReanudarMusica();
        }
    }
}