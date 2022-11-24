using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidMenu : MonoBehaviour
{
    GameManager gameManager;
    MenuPausa menu;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        menu = FindObjectOfType<MenuPausa>();

        menu.UI.SetActive(false);
        gameManager.Save();
    }
    void Update()
    {
     if(Input.GetKey(KeyCode.Space))
        {

            SceneManager.LoadScene("MainRestaurant");
            menu.UI.SetActive(true);
        }
    }
}
