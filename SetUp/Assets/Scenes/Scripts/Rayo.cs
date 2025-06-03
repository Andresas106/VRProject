using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Genera un rayo de energía entre este objeto y el objetivo 'final',
/// usando puntos interpolados con pequeñas desviaciones.
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class Rayo : MonoBehaviour
{
    [Header("Objetivo final del rayo")]
    public Transform final;

    [Header("Puntos del rayo")]
    public int cantidadPuntos = 10;

    [Header("Parámetros visuales")]
    public float dispersion = 0.1f;
    public float frecuencia = 0.05f;

    private LineRenderer line;
    private float tiempo = 0f;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = cantidadPuntos;
    }

    private void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo > frecuencia)
        {
            ActualizarPuntos();
            tiempo = 0f;
        }
    }

    /// <summary>
    /// Actualiza la forma del rayo aplicando puntos aleatoriamente desplazados.
    /// </summary>
    private void ActualizarPuntos()
    {
        List<Vector3> puntos = InterpolarPuntos(transform.position, final.position, cantidadPuntos);

        line.positionCount = puntos.Count;

        for (int i = 0; i < puntos.Count; i++)
        {
            line.SetPosition(i, puntos[i]);
        }
    }

    /// <summary>
    /// Genera una lista de puntos interpolados entre dos posiciones, con pequeñas desviaciones.
    /// </summary>
    private List<Vector3> InterpolarPuntos(Vector3 principio, Vector3 final, int totalPoints)
    {
        List<Vector3> lista = new List<Vector3>();

        for (int i = 0; i < totalPoints; i++)
        {
            float t = (float)i / (totalPoints - 1); // -1 para que el último punto sea exactamente el final
            Vector3 punto = Vector3.Lerp(principio, final, t) + DesfaseAleatorio();
            lista.Add(punto);
        }

        return lista;
    }

    /// <summary>
    /// Genera un pequeño desplazamiento aleatorio para hacer el rayo más orgánico.
    /// </summary>
    private Vector3 DesfaseAleatorio()
    {
        return Random.insideUnitSphere * dispersion;
    }
}
