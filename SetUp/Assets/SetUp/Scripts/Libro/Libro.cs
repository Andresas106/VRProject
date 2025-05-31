using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Libro : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private bool hasActivated = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnBookGrabbed);
    }

    private void OnBookGrabbed(SelectEnterEventArgs args)
    {
        if (hasActivated) return;

        hasActivated = true;

        Debug.Log("Libro recogido, activando mecanismo...");

        // Opción A: Usas animación
       /* if (wallAnimator != null)
        {
            wallAnimator.SetTrigger("OpenSecretWall");
        }

        // Opción B: Desactivas el muro (como si desapareciera)
        if (secretWall != null)
        {
            secretWall.SetActive(false);
        }*/

        // Opción C: Mueves la pared
        // StartCoroutine(MoveWallCoroutine());
    }
}
