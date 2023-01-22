using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaZumos : MonoBehaviour
{
    Player player;
    bool colision;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        //la maquina de zumos funciona exactamente igual que la cocina pero solo que aqui en vez de crear un ojeto aparte directamente
        //si se detecta que en uno de los tres ints del array comandas existe un uno se llama el player.coger para coger un objeto zumo (que es el 1)
        //elimina este por un cero y se recoloca el array
        if (colision == true)
        {
            if (player.Inventario[0] == 0)
            {
                if (Input.GetKeyDown((player.coger)) && (player.Comandas[0] == 1))
                {
                    player.Comandas[0] = 0;
                    player.Comandas[0] = player.Comandas[1];
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(1);
                }
                else if (Input.GetKeyDown((player.coger)) && (player.Comandas[1] == 1))
                {
                    player.Comandas[1] = 0;
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(1);
                }
                else if (Input.GetKeyDown((player.coger)) && (player.Comandas[2] == 1))
                {
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(1);
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
