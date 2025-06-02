using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Libro : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool hasActivated = false;

    [Header("Referencia al Animator externo")]
    public Animator externalAnimator; // <- arrástralo en el Inspector

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnBookGrabbed);
    }

    private void OnBookGrabbed(SelectEnterEventArgs args)
    {
        if (hasActivated) return;
        hasActivated = true;

        Debug.Log("Libro recogido, activando trigger 'Libreria'...");

        if (externalAnimator != null)
        {
            externalAnimator.SetTrigger("libreria");
        }
        else
        {
            Debug.LogWarning("No se ha asignado el Animator externo.");
        }
    }
}
