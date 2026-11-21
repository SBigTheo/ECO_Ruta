using UnityEngine;

public class MusicaEscena : MonoBehaviour
{
    [Header("Clip de Musica para esta Escena")]
    public AudioClip clipMusica;

    void Start()
    {
        if (GestorAudio.instancia != null && clipMusica != null)
        {
            GestorAudio.instancia.ReproducirMusica(clipMusica);
        }
    }
}