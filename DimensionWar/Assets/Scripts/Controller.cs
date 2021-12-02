using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour{

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void ChangeScene(string nombre)
    {
        print("Cambiar escena a " + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void Exit()
    {
        print("Sair del juego");
        Application.Quit();
    }
}
