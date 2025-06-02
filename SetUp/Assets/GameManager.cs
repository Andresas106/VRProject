using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void Salir()
    {
          public GameObject panelConfirmarSalir;

    public void MostrarPanelSalir()
    {
        panelConfirmarSalir.SetActive(true);
    }

    public void CancelarSalir()
    {
        panelConfirmarSalir.SetActive(false);
    }

    public void ConfirmarSalir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
}
