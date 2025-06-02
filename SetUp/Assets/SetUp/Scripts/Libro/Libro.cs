using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class LibroConCambioDeEscena : MonoBehaviour
{
    [Header("Animator del objeto externo")]
    public Animator externalAnimator;

    [Header("Nombre de la escena a cargar")]
    public string sceneToLoad = "NombreDeTuEscena";

    [Header("Fade")]
    public Image fadeImage; // Imagen negra del canvas
    public float fadeDuration = 1.5f;

    private XRGrabInteractable grabInteractable;
    private bool hasActivated = false;

    void Awake()
    {
        // Si hay fadeImage asignada, hacer fade IN al iniciar
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 1f;
            fadeImage.color = c;
            StartCoroutine(FadeIn());
        }
    }

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
            grabInteractable.selectEntered.AddListener(OnBookGrabbed);
    }

    private void OnBookGrabbed(SelectEnterEventArgs args)
    {
        if (hasActivated) return;
        hasActivated = true;

        Debug.Log("Libro recogido → activando animación.");
        if (externalAnimator != null)
        {
            externalAnimator.SetTrigger("libreria");

            // Espera a que acabe la animación y luego hace el fade + carga
            StartCoroutine(EjecutarCambioDeEscenaTrasDelay(2f)); // Ajusta el delay si la animación dura más
        }
        else
        {
            Debug.LogWarning("No hay animator externo asignado.");
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator EjecutarCambioDeEscenaTrasDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(FadeAndLoadScene());
    }

    private IEnumerator FadeAndLoadScene()
    {
        if (fadeImage != null)
        {
            float t = 0f;
            Color color = fadeImage.color;

            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                color.a = Mathf.Clamp01(t / fadeDuration);
                fadeImage.color = color;
                yield return null;
            }
        }

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }
}
