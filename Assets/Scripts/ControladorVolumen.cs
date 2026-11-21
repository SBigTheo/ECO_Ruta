using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorVolumen : MonoBehaviour
{
    public static ControladorVolumen instancia;

    public AudioMixer audioMixer;

    public Slider sliderMusica;
    public Slider sliderSFX;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += AlCargarEscena;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    void AlCargarEscena(Scene scene, LoadSceneMode mode)
    {
        // Buscar los sliders nuevos en la escena que acaba de cargar
        Slider[] sliders = FindObjectsByType<Slider>(FindObjectsSortMode.None);

        foreach (Slider s in sliders)
        {
            if (s.name == "SliderMusica")
            {
                sliderMusica = s;
                ConfigurarSliderMusica();
            }
            else if (s.name == "SliderSFX")
            {
                sliderSFX = s;
                ConfigurarSliderSFX();
            }
        }
    }

    void Start()
    {
        if (sliderMusica != null) ConfigurarSliderMusica();
        if (sliderSFX != null) ConfigurarSliderSFX();
    }

    void ConfigurarSliderMusica()
    {
        float volMusicaGuardado = PlayerPrefs.GetFloat("VolumenMusica", 0.75f);
        sliderMusica.value = volMusicaGuardado;
        sliderMusica.onValueChanged.RemoveAllListeners();
        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        CambiarVolumenMusica(volMusicaGuardado);
    }

    void ConfigurarSliderSFX()
    {
        float volSFXGuardado = PlayerPrefs.GetFloat("VolumenSFX", 1f);
        sliderSFX.value = volSFXGuardado;
        sliderSFX.onValueChanged.RemoveAllListeners();
        sliderSFX.onValueChanged.AddListener(CambiarVolumenSFX);
        CambiarVolumenSFX(volSFXGuardado);
    }

    public void CambiarVolumenMusica(float valor)
    {
        if (audioMixer != null)
        {
            float db = Mathf.Log10(Mathf.Max(valor, 0.0001f)) * 20f;
            audioMixer.SetFloat("VolumenMusica", db);
            PlayerPrefs.SetFloat("VolumenMusica", valor);
        }
    }

    public void CambiarVolumenSFX(float valor)
    {
        if (audioMixer != null)
        {
            float db = Mathf.Log10(Mathf.Max(valor, 0.0001f)) * 20f;
            audioMixer.SetFloat("VolumenSFX", db);
            PlayerPrefs.SetFloat("VolumenSFX", valor);
        }
    }
}