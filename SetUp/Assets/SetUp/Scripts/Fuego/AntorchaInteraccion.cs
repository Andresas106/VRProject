using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntorchaInteraccion : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private GameObject particlesToActivate;

    public void ActivateTarget()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if(particlesToActivate != null)
        {
            particlesToActivate.SetActive(true);
        }
    }
}
