using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidMenu : MonoBehaviour
{
    GameManager gameManager;
    MenuPausa menu;

    InfoMidMenu midMenu;

    int cont;
    void Start()
    {
        cont = 0;
        gameManager = FindObjectOfType<GameManager>();
        menu = FindObjectOfType<MenuPausa>();
        midMenu = FindObjectOfType<InfoMidMenu>();
        gameManager.Save();
    }
    void Update()
    {
     if(Input.GetKey(KeyCode.Space))
        {
            if(cont == 0)
            {
                midMenu.SumDinero();
                cont++;
            }
            else if (cont == 1)
            {
                SceneManager.LoadScene("MainRestaurant");
            }
        }
    }
}
