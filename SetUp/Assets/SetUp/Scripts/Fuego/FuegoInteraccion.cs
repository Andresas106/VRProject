using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoInteraccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Busca un componente del tipo "TargetActivator" en el objeto con el que colisiona
        AntorchaInteraccion activator = other.GetComponent<AntorchaInteraccion>();
        Nivel3Rayos activatorRayos = other.GetComponent<Nivel3Rayos>();

        if (activator != null)
        {
            activator.ActivateTarget();
        }

        if (activatorRayos != null)
        {
            activatorRayos.ActivateTarget();
        }
    }
}
