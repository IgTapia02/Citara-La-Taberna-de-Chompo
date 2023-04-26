using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    [SerializeField]
    GameObject UI;

    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject OptionsMenu;
    [SerializeField]
    GameObject ImageTutorial;

    bool pause=false;
    GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        //si el dia es igual a 1 se activan las imagenes del tutorial
        if (manager.gameData.dia == 1)
        {
            Time.timeScale = 0f;//esto para el juego
            ImageTutorial.SetActive(true);
            UI.SetActive(false);//se oculta la ui y se muestran las imagenes del tutorial
        }
        else
        {
            Time.timeScale = 1f;//esto vuelve a ponerlo en tiempo normal
        }
    }
    void Update()
    {
        //se pulsa el escape y si el menu no esta activo este llama a pausa
            if (Input.GetKey(KeyCode.Escape))
            {
                if (pause == false)
                {
                    Pausa();
                }
            }
    }

    //funcion que hace que el juego pase al menu principal, se destruye el game manager puesto que en este se crea otro
    public void MainMenu()
    {
        Destroy(manager);
        SceneManager.LoadScene("MainMenu");
    }
    //se pone a true el pausa, se para el juego se quita el canvas de la ui y se activa el canvas de menu
    public void Pausa()
    {
        pause = true;
        Time.timeScale = 0f;
        UI.SetActive(false);
        PauseMenu.SetActive(true);
    }
    //hace lo contrario que el pausa()
    public void Resume()
    {
        pause = false;
        Time.timeScale = 1f;
        UI.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void Options()
    {
        OptionsMenu.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void GoMenu()
    {
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
    //funcion que se ejecuta cuando se termina el tutorial 
    public void FinTutorial()
    {
        UI.SetActive(true);
        ImageTutorial.SetActive(false);
        Time.timeScale = 1f;
    }

}

