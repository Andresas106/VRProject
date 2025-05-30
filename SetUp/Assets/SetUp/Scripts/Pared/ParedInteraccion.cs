using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInteraccion : MonoBehaviour
{

    [SerializeField] private GameObject objectDestroyed;

    public void ActivateTarget()
    {
        Instantiate(objectDestroyed, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
