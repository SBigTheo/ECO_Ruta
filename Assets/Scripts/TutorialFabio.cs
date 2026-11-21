using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TutorialFabio : MonoBehaviour
{
    [Header("UI - Burbujas de Dialogo")]
    public GameObject[] burbujasDialogo;

    [Header("Fabio")]
    public Image imagenFabio;
    public Sprite[] spritesFabio;
    public int[] spriteIndexPorBurbuja;

    [Header("Audios de Dialogo")]
    public AudioSource audioSource;
    public AudioClip[] audiosBurbuja;

    [Header("Escena Siguiente")]
    public string nombreSiguienteEscena = "Nivel1";

    private int indiceActual = 0;
    private bool tutorialTerminado = false;
    private bool[] audioYaReproducido;

    void Start()
    {
        foreach (var burbuja in burbujasDialogo)
        {
            if (burbuja != null) burbuja.SetActive(false);
        }

        if (burbujasDialogo.Length == 0)
        {
            Debug.LogError("No hay burbujas de dialogo configuradas.");
            return;
        }

        audioYaReproducido = new bool[burbujasDialogo.Length];
        MostrarBurbuja(0);
    }

    void Update()
    {
        if (tutorialTerminado) return;

        bool toqueDetectado = false;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            toqueDetectado = true;
        }
        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            toqueDetectado = true;
        }

        if (toqueDetectado)
        {
            SiguienteDialogo();
        }
    }

    void SiguienteDialogo()
    {
        if (indiceActual < burbujasDialogo.Length && burbujasDialogo[indiceActual] != null)
        {
            burbujasDialogo[indiceActual].SetActive(false);
        }

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        indiceActual++;

        if (indiceActual >= burbujasDialogo.Length)
        {
            TerminarTutorial();
        }
        else
        {
            MostrarBurbuja(indiceActual);
        }
    }

    void MostrarBurbuja(int index)
    {
        if (burbujasDialogo[index] != null)
        {
            burbujasDialogo[index].SetActive(true);
        }

        if (spritesFabio.Length > 0 && spriteIndexPorBurbuja.Length > index)
        {
            int spriteIdx = spriteIndexPorBurbuja[index];
            if (spriteIdx >= 0 && spriteIdx < spritesFabio.Length)
            {
                imagenFabio.sprite = spritesFabio[spriteIdx];
            }
        }

        ReproducirAudioBurbuja(index);
    }

    void ReproducirAudioBurbuja(int index)
    {
        if (audioSource == null || audiosBurbuja.Length == 0) return;
        if (index >= audiosBurbuja.Length || audiosBurbuja[index] == null) return;

        if (!audioYaReproducido[index])
        {
            audioSource.clip = audiosBurbuja[index];
            audioSource.Play();
            audioYaReproducido[index] = true;
        }
    }

    void TerminarTutorial()
    {
        tutorialTerminado = true;

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}