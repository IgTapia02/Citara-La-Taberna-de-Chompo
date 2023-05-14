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
    public void ComprarRestaurante1()
    {
        gameManager.gameData.bar1 = true;
    }
    public void ComprarRestaurante2()
    {
        gameManager.gameData.bar1 = false;
        gameManager.gameData.bar2 = true;
    }
    void Update()
    {
        //con la tecla espacio se activan las interacciones con el midmenu, primero sumar el dinero luego se vuelve al restaurante
        if(Input.GetKeyDown(KeyCode.Space))
        {
                if (cont == 0)
                {
                    StartCoroutine(midMenu.Esperar()); //funcion que hace esperar unos milisegundos para que el contador se vea mas estetico
                    cont++;//se suma el dinero dia al dinero general
                }
                else if (cont == 1)
                {
                    gameManager.gameData.dia++;

                    if (gameManager.gameData.dia > 6)
                    {
                        gameManager.gameData.dia = 1;
                        gameManager.gameData.semana++;
                        gameManager.gameData.dineroPJ -= gameManager.pagoMes1;
                    }

                    if (gameManager.gameData.bar1 == true)
                    {
                        gameManager.dineroDia = 0;//se renueva el dinero de ese dia
                        SceneManager.LoadScene("Resttaurante_002Final");//se vuelve al restaurante
                    }
                    else if(gameManager.gameData.bar2 == true)
                    {
                        gameManager.dineroDia = 0;//se renueva el dinero de ese dia
                        SceneManager.LoadScene("Resttaurante_003Final");//se vuelve al restaurante
                    }
                    else
                    { 
                        gameManager.dineroDia = 0;//se renueva el dinero de ese dia
                        SceneManager.LoadScene("Resttaurante_001Final");//se vuelve al restaurante
                    }

                }
        }
    }
}
