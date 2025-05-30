using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoInteraccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Busca un componente del tipo "TargetActivator" en el objeto con el que colisiona
        AntorchaInteraccion activator = other.GetComponent<AntorchaInteraccion>();

        if (activator != null)
        {
            activator.ActivateTarget();
        }
    }
}
