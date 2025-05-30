using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuerzaInteraccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Busca un componente del tipo "TargetActivator" en el objeto con el que colisiona
        ParedInteraccion activator = other.GetComponent<ParedInteraccion>();

        if (activator != null)
        {
            activator.ActivateTarget();
        }
    }
}
