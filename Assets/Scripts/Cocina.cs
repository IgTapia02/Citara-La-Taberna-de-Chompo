using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocina : MonoBehaviour
{
    bool colision;
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(colision== true)
        {
            if (player.Inventario[0] == 0)
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
}
