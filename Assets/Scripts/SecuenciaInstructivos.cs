using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PasoInstructivo
{
    public Sprite imagenNPC;
    public string textoDialogo;
}

public class SecuenciaInstructivos : MonoBehaviour
{
    public PasoInstructivo[] pasos;
    public Image imagenNPC;
    public TextMeshProUGUI textoDialogo;
    public GameObject panelInstructivos;
    public GameObject juegoHabilitado; // Referencia al objeto que controla el juego

    private int indiceActual = 0;
    private bool secuenciaTerminada = false;

    void Start()
    {
        panelInstructivos.SetActive(true);
        juegoHabilitado.SetActive(false); // El juego no arranca hasta terminar
        MostrarPaso(0);
    }

    public void AvanzarPaso()
    {
        if (secuenciaTerminada) return;

        indiceActual++;
        if (indiceActual < pasos.Length)
        {
            MostrarPaso(indiceActual);
        }
        else
        {
            TerminarSecuencia();
        }
    }

    void MostrarPaso(int indice)
    {
        imagenNPC.sprite = pasos[indice].imagenNPC;
        textoDialogo.text = pasos[indice].textoDialogo;
    }

    void TerminarSecuencia()
    {
        secuenciaTerminada = true;
        panelInstructivos.SetActive(false);
        juegoHabilitado.SetActive(true); // Habilita el gameplay
    }
}