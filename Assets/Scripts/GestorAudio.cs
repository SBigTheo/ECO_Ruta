using UnityEngine;
using UnityEngine.Audio;

public class GestorAudio : MonoBehaviour
{
    public static GestorAudio instancia;

    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Clips de Musica")]
    public AudioClip musicaMenu;
    public AudioClip musicaNivel1;
    public AudioClip musicaNivel2;
    public AudioClip musicaNivel3;

    [Header("Audio Mixer (Opcional)")]
    public AudioMixer audioMixer;
    public AudioMixerGroup grupoMusica;

    private float volumenOriginalMusica = 0f;
    private bool pausado = false;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.outputAudioMixerGroup = grupoMusica;
        }

        ReproducirMusica(musicaMenu);
    }

    public void ReproducirMusica(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;

        if (audioSource.clip == clip && audioSource.isPlaying) return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PausarMusica()
    {
        if (pausado) return;
        pausado = true;

        if (audioMixer != null)
        {
            audioMixer.GetFloat("VolumenMusica", out volumenOriginalMusica);
            audioMixer.SetFloat("VolumenMusica", volumenOriginalMusica - 4f);
        }
        else if (audioSource != null)
        {
            volumenOriginalMusica = audioSource.volume;
            audioSource.volume = volumenOriginalMusica * 0.6f;
        }
    }

    public void ReanudarMusica()
    {
        if (!pausado) return;
        pausado = false;

        if (audioMixer != null)
        {
            audioMixer.SetFloat("VolumenMusica", volumenOriginalMusica);
        }
        else if (audioSource != null)
        {
            audioSource.volume = volumenOriginalMusica;
        }
    }
}