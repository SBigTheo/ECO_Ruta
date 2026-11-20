using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialFabio : MonoBehaviour
{
    [Header("UI - Burbujas de Diálogo")]
    public GameObject[] burbujasDialogo;

    [Header("Fabio")]
    public Image imagenFabio;
    public Sprite[] spritesFabio;
    public int[] spriteIndexPorBurbuja;

    [Header("Escena Siguiente")]
    public string nombreSiguienteEscena = "Nivel1";

    private int indiceActual = 0;
    private bool tutorialTerminado = false;

    void Start()
    {
        foreach (var burbuja in burbujasDialogo)
        {
            if (burbuja != null) burbuja.SetActive(false);
        }

        if (burbujasDialogo.Length == 0)
        {
            Debug.LogError("No hay burbujas de diálogo configuradas.");
            return;
        }

        MostrarBurbuja(0);
    }

    public void SiguienteDialogo()
    {
        if (tutorialTerminado) return;

        if (indiceActual < burbujasDialogo.Length && burbujasDialogo[indiceActual] != null)
        {
            burbujasDialogo[indiceActual].SetActive(false);
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
    }

    void TerminarTutorial()
    {
        tutorialTerminado = true;
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}