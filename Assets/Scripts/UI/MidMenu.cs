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
        gameManager.Save();//se guarda la partida cada vez que se pasa al menu de entre dias
    }
    void Update()
    {
        //con la tecla espacio se activan las interacciones con el midmenu, primero sumar el dinero luego se vuelve al restaurante
     if(Input.GetKeyDown(KeyCode.Space))
        {
            //esto se quitara, solo sireve para la demo, solo ocurre el sexto dia de la demo
            if (gameManager.findemo == true)
            {
                if (cont == 0)
                {
                    cont++;
                }
                else if (cont == 1)
                {
                    gameManager.NewGame();
                }
            }
            //esto ocurre el rsto de dias
            else
            {
                if (cont == 0)
                {
                    StartCoroutine(midMenu.Esperar()); //funcion que hace esperar unos milisegundos para que el contador se vea mas estetico
                    cont++;//se suma el dinero dia al dinero general

                }
                else if (cont == 1)
                {

                    gameManager.dineroDia = 0;//se renueva el dinero de ese dia
                    SceneManager.LoadScene("MainRestaurant");//se vuelve al restaurante
                }
            }
        }
    }
}
