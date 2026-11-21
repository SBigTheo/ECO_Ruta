using UnityEngine;

public class GestorSFX : MonoBehaviour
{
    public static GestorSFX instancia;

    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Efectos de Sonido")]
    public AudioClip sfxAtropello;
    public AudioClip sfxRecoleccion;
    public AudioClip sfxBoton;
    public AudioClip sfxDerrota;
    public AudioClip sfxVictoria;

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
            return;
        }
    }

    public void ReproducirSFX(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void SonidoAtropello() { ReproducirSFX(sfxAtropello); }
    public void SonidoRecoleccion() { ReproducirSFX(sfxRecoleccion); }
    public void SonidoBoton() { ReproducirSFX(sfxBoton); }
    public void SonidoDerrota() { ReproducirSFX(sfxDerrota); }
    public void SonidoVictoria() { ReproducirSFX(sfxVictoria); }
}