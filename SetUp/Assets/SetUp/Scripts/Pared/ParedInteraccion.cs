using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInteraccion : MonoBehaviour
{

    [SerializeField] private GameObject objectDestroyed;
    [SerializeField] private GameObject cadenas;

    public void ActivateTarget()
    {
        GameObject obj = Instantiate(objectDestroyed, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Destroy(obj, 3f);

        if (objectDestroyed.name == "TotemRoto" )
        {
            if(cadenas != null )  Destroy(cadenas);
        }
    }
}
