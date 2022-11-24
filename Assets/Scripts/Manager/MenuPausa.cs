using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    [SerializeField]
    GameObject UI;

    [SerializeField]
    GameObject PauseMenu;
    bool pause=false;

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

