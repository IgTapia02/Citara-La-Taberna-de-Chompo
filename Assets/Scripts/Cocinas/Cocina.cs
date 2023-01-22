
//Esta codigo fue un primer intento de hacer la cocina, no lo pense demasiado y le di mil vueltas asique lo acabe desechando y haciendolo otra vez en el script cocina2

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocina : MonoBehaviour
{
    //[SerializeField]
    float tiempoCocinado;
    bool colision;
    Player player;
    bool cocina1, cocina2, cocina3;
    bool listo1, listo2, listo3;
    int plato1, plato2, plato3;
    float time1, time2, time3;
    int[] mostrador = new int[3];

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (cocina1 == true)
        {
            time1 += Time.deltaTime;
            if (time1 > tiempoCocinado)
            {
                listo1 = true;
                if (mostrador[0] == 0)
                {
                    mostrador[0] = plato1;
                }else if (mostrador [1]==0)
                {
                    mostrador[1] = plato1;
                }
                else if(mostrador [2]==0)
                {
                    mostrador[2] = plato1;
                }
                time1= 0;
            }
        }
        if (cocina2 == true)
        {
            time2 += Time.deltaTime;
            if (time2 > tiempoCocinado)
            {
                listo2 = true;
                if (mostrador[0] == 0)
                {
                    mostrador[0] = plato1;
                }
                else if (mostrador[1] == 0)
                {
                    mostrador[1] = plato1;
                }
                else if (mostrador[2] == 0)
                {
                    mostrador[2] = plato1;
                }
                time2 = 0;
            }
        }
        if (cocina3 == true)
        {
            time3 += Time.deltaTime;
            if (time3 > tiempoCocinado)
            {
                listo3 = true;
                if (mostrador[0] == 0)
                {
                    mostrador[0] = plato1;
                }
                else if (mostrador[1] == 0)
                {
                    mostrador[1] = plato1;
                }
                else if (mostrador[2] == 0)
                {
                    mostrador[2] = plato1;
                }
                time3 = 0;
            }
        }
        if (colision== true)
        {
            if (Input.GetKeyDown(player.dejar))
            {
                if (player.Comandas[0] != 0)
                {
                    if (cocina1 == false || cocina2 == false || cocina3 == false)
                    {
                        if (cocina1 == false)
                        {
                            plato1 = player.Comandas[0];
                            player.Comandas[0] = 0;
                            player.Comandas[0] = player.Comandas[1];
                            player.Comandas[1] = player.Comandas[2];
                            player.Comandas[2] = 0;
                            cocina1 = true;
                        }
                        else if (cocina2 == false)
                        {
                            plato2 = player.Comandas[0];
                            player.Comandas[0] = 0;
                            player.Comandas[0] = player.Comandas[1];
                            player.Comandas[1] = player.Comandas[2];
                            player.Comandas[2] = 0;
                            cocina2 = true;
                        }
                        else if (cocina3 == false)
                        {
                            plato3 = player.Comandas[0];
                            player.Comandas[0] = 0;
                            player.Comandas[0] = player.Comandas[1];
                            player.Comandas[1] = player.Comandas[2];
                            player.Comandas[2] = 0;
                            cocina3 = true;
                        }
                    }
                }
            }
            /*if (player.Inventario[0] == 0)
            {
                if (Input.GetKeyDown((player.dejar)) && (player.Comandas[0] == 2))
                {
                    player.Comandas[0] = 0;
                    player.Comandas[0] = player.Comandas[1];
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(2);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[0] == 3))
                {
                    player.Comandas[0] = 0;
                    player.Comandas[0] = player.Comandas[1];
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(3);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[0] == 4))
                {
                    player.Comandas[0] = 0;
                    player.Comandas[0] = player.Comandas[1];
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(4);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[0] == 5))
                {
                    player.Comandas[0] = 0;
                    player.Comandas[0] = player.Comandas[1];
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(5);
                }
            }
           if (player.Inventario[0] == 0)
            {

                if (Input.GetKeyDown((player.dejar)) && (player.Comandas[1] == 2))
                {
                    player.Comandas[1] = 0;
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(2);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[1] == 3))
                {
                    player.Comandas[1] = 0;
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(3);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[1] == 4))
                {
                    player.Comandas[1] = 0;
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(4);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[1] == 5))
                {
                    player.Comandas[1] = 0;
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(5);
                }


            }
           
            
            if (player.Inventario[0] == 0)
            {

                if (Input.GetKeyDown((player.dejar)) && (player.Comandas[3] == 2))
                {
                    player.Comandas[3] = 0;
                    player.numcomandas--;
                    player.Coger(2);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[3] == 3))
                {
                    player.Comandas[3] = 0;                  
                    player.numcomandas--;
                    player.Coger(3);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[3] == 4))
                {
                    player.Comandas[3] = 0;
                    player.numcomandas--;
                    player.Coger(4);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[3] == 5))
                {
                    player.Comandas[3] = 0;
                    player.numcomandas--;
                    player.Coger(5);
                }
            }

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colision = false;
        }
    }
}*/
