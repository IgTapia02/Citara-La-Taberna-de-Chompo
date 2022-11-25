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

    GameObject manager;

    bool pause=false;

    GameManager gameManager;

    void Start()
    {
        manager = GameObject.Find("GameManager");
        Time.timeScale = 1f;
        gameManager = FindObjectOfType<GameManager>();
       
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(pause == false)
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

}

