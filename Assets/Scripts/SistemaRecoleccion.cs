using UnityEngine;
using System;

public class SistemaRecoleccion : MonoBehaviour
{
    [Header("Configuración")]
    public int residuosTotalesRequeridos = 8;

    public int ResiduosRecolectados { get; private set; } = 0;

    public event Action<int, int> OnResiduoRecolectado;
    public event Action OnMetaAlcanzada;

    private bool metaAlcanzada = false;

    public void Recolectar()
    {
        if (metaAlcanzada) return;

        ResiduosRecolectados++;

        OnResiduoRecolectado?.Invoke(ResiduosRecolectados, residuosTotalesRequeridos);

        if (ResiduosRecolectados >= residuosTotalesRequeridos)
        {
            metaAlcanzada = true;
            OnMetaAlcanzada?.Invoke();
        }
    }

    public bool TieneTodosLosResiduos()
    {
        return ResiduosRecolectados >= residuosTotalesRequeridos;
    }
}