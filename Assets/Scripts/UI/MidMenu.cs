using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidMenu : MonoBehaviour
{
    GameManager gameManager;

    InfoMidMenu midMenu;

    public bool start;
    int cont;
    void Start()
    {
        start = false;
        cont = 0;
        gameManager = FindObjectOfType<GameManager>();
        midMenu = FindObjectOfType<InfoMidMenu>();
        gameManager.Save();
    }
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space))
        {
            if(cont == 0)
            {
                StartCoroutine(midMenu.Esperar());
                cont++;
            }
            else if (cont == 1)
            {
                SceneManager.LoadScene("MainRestaurant");
            }
        }
    }
}
