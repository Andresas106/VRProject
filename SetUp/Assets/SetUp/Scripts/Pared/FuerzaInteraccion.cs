using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuerzaInteraccion : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // Busca un componente del tipo "TargetActivator" en el objeto con el que colisiona
        ParedInteraccion activator = other.gameObject.GetComponent<ParedInteraccion>();

        if (activator != null)
        {
            activator.ActivateTarget();
        }
    }
}
