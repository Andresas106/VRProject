using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntorchaInteraccion : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    public void ActivateTarget()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
