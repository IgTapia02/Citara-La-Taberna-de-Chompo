using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MidMenu : MonoBehaviour
{
    GameManager gameManager;
    InfoMidMenu midMenu;
    public bool start;
    int cont;
    [SerializeField] GameObject boton1, boton2;
    [SerializeField] int precioBar1, precioBar2;
    [SerializeField] TMP_Text restDinero, pagoMes;
    void Start()
    {
        start = false;
        cont = 0;
        gameManager = FindObjectOfType<GameManager>();
        midMenu = FindObjectOfType<InfoMidMenu>();
        gameManager.Save();//se guarda la partida cada vez que se pasa al menu de entre dias
        boton1.SetActive(false);
        boton2.SetActive(false);
    }
    public void ComprarRestaurante1()
    {
        if (!gameManager.gameData.bar1)
        {
            if (gameManager.gameData.dineroPJ >= precioBar1)
            {
                gameManager.gameData.bar1 = true;
                gameManager.gameData.dineroPJ -= precioBar1;
                gameManager.dinMidDia = gameManager.gameData.dineroPJ;
                restDinero.text = "-" + precioBar1 + "= " + gameManager.gameData.dineroPJ;
            }
            else
            {
                restDinero.text = "Not Funds";
            }
        }
    }
    public void ComprarRestaurante2()
    {
        if (gameManager.gameData.bar1 && !gameManager.gameData.bar2)
        {
            if (gameManager.gameData.dineroPJ >= precioBar2)
            {
                gameManager.gameData.bar1 = false;
                gameManager.gameData.bar2 = true;
                gameManager.gameData.dineroPJ -= precioBar2;
                gameManager.dinMidDia = gameManager.gameData.dineroPJ;
                restDinero.text = "-" + precioBar2 + "= " + gameManager.gameData.dineroPJ;
            }
            else
            {
                restDinero.text = "Not Funds";
            }

        }
    }
    void Update()
    {
        //con la tecla espacio se activan las interacciones con el midmenu, primero sumar el dinero luego se vuelve al restaurante
        if(Input.GetKeyDown(KeyCode.Space))
        {
                if (cont == 0)
                {
                    if (gameManager.dineroDia > 0)
                    {
                        StartCoroutine(midMenu.Esperar()); //funcion que hace esperar unos milisegundos para que el contador se vea mas estetico
                    }
                    cont++;//se suma el dinero dia al dinero general
                    if (gameManager.gameData.dia == 6 || gameManager.gameData.semana>1)
                    {
                        if (!gameManager.gameData.bar1 && !gameManager.gameData.bar2)
                        {
                            boton1.SetActive(true);
                            restDinero.text = precioBar1 + "$";
                        }
                        if (!gameManager.gameData.bar2 && gameManager.gameData.bar1)
                        {
                            boton2.SetActive(true);
                            restDinero.text = precioBar2 + "$";
                        }
                         
                        if (gameManager.gameData.dia == 6)
                        {
                         
                            if (gameManager.gameData.semana == 1)
                            {
                                pagoMes.text = "Impuesto semana: " + gameManager.gameData.semana + " = " + gameManager.pagoMes1;
                            }

                            if (gameManager.gameData.semana == 2)
                            {
                                pagoMes.text = "Impuesto semana" + gameManager.gameData.semana + " = " + gameManager.pagoMes2;
                            }

                            if (gameManager.gameData.semana == 3)
                            {
                                pagoMes.text = "Impuesto semana" + gameManager.gameData.semana + " = " + gameManager.pagoMes3;
                            }
                        }
                    }
                }
                else if (cont == 1)
                {
                    gameManager.gameData.dia++;

                    if (gameManager.gameData.dia > 6)
                    {
                        gameManager.gameData.dia = 1;
                        if(gameManager.gameData.semana == 1)
                        {
                            gameManager.gameData.dineroPJ -= gameManager.pagoMes1;
                        }
                            
                        if (gameManager.gameData.semana == 2)
                        {
                            gameManager.gameData.dineroPJ -= gameManager.pagoMes2;
                        }
                            
                        if (gameManager.gameData.semana == 3)
                        {
                            gameManager.gameData.dineroPJ -= gameManager.pagoMes3;
                        }
                           
                            gameManager.gameData.semana++;
                    }

                    if (gameManager.gameData.dineroPJ >= 0 || gameManager.gameData.semana<=3)
                    {
                        if (gameManager.gameData.bar1 == true)
                        {
                            gameManager.dineroDia = 0;//se renueva el dinero de ese dia
                            SceneManager.LoadScene("Resttaurante_002Final");//se vuelve al restaurante
                        }
                        else if (gameManager.gameData.bar2 == true)
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
                    else
                    {
                        gameManager.ResetGame();
                    }
                    

                }
        }
    }
}
