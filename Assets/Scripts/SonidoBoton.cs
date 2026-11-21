using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SonidoBoton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ReproducirSonido);
    }

    void ReproducirSonido()
    {
        if (GestorSFX.instancia != null)
        {
            GestorSFX.instancia.SonidoBoton();
        }
    }
}