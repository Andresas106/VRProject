using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel3Rayos : MonoBehaviour
{
    [Header("Activaciones principales")]
    [SerializeField] private GameObject objectToActivate;
    [SerializeField] private GameObject particlesToActivate;

    [Header("GameObjects extra")]
    [SerializeField] private GameObject extra1;
    [SerializeField] private GameObject extra2;
    [SerializeField] private GameObject extra3;
    [SerializeField] private GameObject extra4;
    [SerializeField] private GameObject extra5;

    [Header("Animator externo")]
    [SerializeField] private Animator puertaAnimatorIz;
    [SerializeField] private Animator puertaAnimatorDe;

    [Header("Duración del evento")]
    [SerializeField] private float duracionEvento = 10f;

    public void ActivateTarget()
    {
        Debug.Log("ACtivateTarget");
        StartCoroutine(ActivarEvento());
    }

    private IEnumerator ActivarEvento()
    {
        // Activar objetos
        if (objectToActivate != null) objectToActivate.SetActive(true);
        if (particlesToActivate != null) particlesToActivate.SetActive(true);
        if (extra1 != null) extra1.SetActive(true);
        if (extra2 != null) extra2.SetActive(true);
        if (extra3 != null) extra3.SetActive(true);
        if (extra4 != null) extra4.SetActive(true);
        if (extra5 != null) extra5.SetActive(true);

        // Activar animación
        if (puertaAnimatorIz != null)
        {
            puertaAnimatorIz.SetTrigger("Puerta");
        }

        // Activar animación
        if (puertaAnimatorDe != null)
        {
            puertaAnimatorDe.SetTrigger("Puerta");
        }

        // Esperar duración
        yield return new WaitForSeconds(duracionEvento);

        // Opcional: desactivar después de la duración (puedes borrar esto si no quieres que se apaguen)
        if (extra1 != null) extra1.SetActive(false);
        if (extra2 != null) extra2.SetActive(false);
        if (extra3 != null) extra3.SetActive(false);
    }
}
