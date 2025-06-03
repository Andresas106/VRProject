using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CambioEscena3 : MonoBehaviour
{
    [Header("Animator del objeto externo")]
    public Animator externalAnimator;

    [Header("Nombre de la escena a cargar")]
    public string sceneToLoad = "NombreDeTuEscena";

    [Header("Fade")]
    public Image fadeImage; // Imagen negra del canvas
    public float fadeDuration = 1.5f;

    private bool hasActivated = false;

    void Awake()
    {
        // Fade in al iniciar
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 1f;
            fadeImage.color = c;
            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasActivated) return;

        // Asegúrate de que el jugador tenga la tag "Player"
        if (other.CompareTag("Player"))
        {
            hasActivated = true;
            Debug.Log("Jugador ha entrado en el trigger.");

            if (externalAnimator != null)
            {
                externalAnimator.SetTrigger("libreria");
                StartCoroutine(EjecutarCambioDeEscenaTrasDelay(2f));
            }
            else
            {
                StartCoroutine(FadeAndLoadScene());
            }
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
