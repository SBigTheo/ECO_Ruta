using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestorTransicion : MonoBehaviour
{
    public static GestorTransicion instancia;

    [Header("Configuracion")]
    public float duracionFundido = 0.5f;

    private Image imagenFundido;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            CrearCanvas();
        }
        else
        {
            Destroy(gameObject);
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

    void CrearCanvas()
    {
        GameObject canvasObj = new GameObject("CanvasTransicion");
        canvasObj.transform.SetParent(transform);

        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);

        canvasObj.AddComponent<GraphicRaycaster>();

        GameObject imagenObj = new GameObject("ImagenFundido");
        imagenObj.transform.SetParent(canvasObj.transform, false);

        imagenFundido = imagenObj.AddComponent<Image>();
        imagenFundido.color = new Color(0, 0, 0, 1);

        RectTransform rt = imagenFundido.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        StartCoroutine(FundidoEntrada());
    }

    public void CambiarEscena(string nombreEscena)
    {
        StartCoroutine(Transicion(nombreEscena));
    }

    public void CambiarEscena(int indiceEscena)
    {
        StartCoroutine(Transicion(indiceEscena));
    }

    private IEnumerator Transicion(string nombreEscena)
    {
        yield return StartCoroutine(FundidoSalida());
        SceneManager.LoadScene(nombreEscena);
    }

    private IEnumerator Transicion(int indiceEscena)
    {
        yield return StartCoroutine(FundidoSalida());
        SceneManager.LoadScene(indiceEscena);
    }

    private void AlCargarEscena(Scene scene, LoadSceneMode mode)
    {
        if (imagenFundido != null)
        {
            imagenFundido.color = new Color(0, 0, 0, 1);
            StartCoroutine(FundidoEntrada());
        }
    }

    private IEnumerator FundidoEntrada()
    {
        float tiempo = 0f;
        while (tiempo < duracionFundido)
        {
            tiempo += Time.unscaledDeltaTime;
            float alpha = 1f - (tiempo / duracionFundido);
            imagenFundido.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        imagenFundido.color = new Color(0, 0, 0, 0);
        imagenFundido.raycastTarget = false;
    }

    private IEnumerator FundidoSalida()
    {
        imagenFundido.raycastTarget = true;
        float tiempo = 0f;
        while (tiempo < duracionFundido)
        {
            tiempo += Time.unscaledDeltaTime;
            float alpha = tiempo / duracionFundido;
            imagenFundido.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        imagenFundido.color = new Color(0, 0, 0, 1);
    }
}