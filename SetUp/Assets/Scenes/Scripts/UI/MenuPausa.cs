using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject locomotionSystem;
    [SerializeField] private GameObject panelPausa;

    public void pausar()
    {
        panelPausa.SetActive(true); // Muestra el menú de pausa
        locomotionSystem.SetActive(false);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void resume()
    {
        panelPausa.SetActive(false); // Oculta el menú de pausa
        locomotionSystem.SetActive(true);
    }
}
