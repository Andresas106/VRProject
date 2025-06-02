using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoaderWithFade : MonoBehaviour
{
    [Header("Nombre de la escena a cargar")]
    public string sceneToLoad;

    [Header("UI de fundido")]
    public Image fadeImage; // Imagen negra en pantalla completa con Canvas

    [Header("Duración del fundido")]
    public float fadeDuration = 1f;

    [Header("Tag del jugador")]
    public string playerTag = "Player";

    private bool hasFaded = false;

    private void OnTriggerStay(Collider other)
    {
        if (hasFaded || !other.CompareTag(playerTag)) return;

        hasFaded = true;
        StartCoroutine(FadeAndLoadScene());
    }


    private IEnumerator FadeAndLoadScene()
    {
        // Fundido a negro
        float t = 0f;
        Color c = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f); // pequeña pausa

        SceneManager.LoadScene(sceneToLoad);
    }
}
