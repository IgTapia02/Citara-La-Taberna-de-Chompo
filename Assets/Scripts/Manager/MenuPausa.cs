using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    [SerializeField]
    public GameObject UI;

    [SerializeField]
    GameObject PauseMenu;

    [SerializeField]
    GameObject ImageTutorial;

    bool pause=false;
    bool fin;
    GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        if (manager.gameData.dia == 1)
        {
            Time.timeScale = 0f;
            ImageTutorial.SetActive(true);
            UI.SetActive(false);
            fin = false;
        }
        else
        {
            Time.timeScale = 1f;
        }
 
        
       
    }
    void Update()
    {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (pause == false)
                {
                    Pausa();
                }
            }
    }

    public void MainMenu()
    {
        Destroy(manager);
        SceneManager.LoadScene("MainMenu");
    }

    public void Pausa()
    {
        pause = true;
        Time.timeScale = 0f;
        UI.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pause = false;
        Time.timeScale = 1f;
        UI.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void FinTutorial()
    {
        UI.SetActive(true);
        ImageTutorial.SetActive(false);
        Time.timeScale = 1f;
        fin = true;
    }

}

