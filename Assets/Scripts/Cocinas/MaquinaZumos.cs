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
        if (colision == true)
        {
            if (player.Inventario[0] == 0)
            {
                if (Input.GetKeyDown((player.dejar)) && (player.Comandas[0] == 1))
                {
                    player.Comandas[0] = 0;
                    player.Comandas[0] = player.Comandas[1];
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(1);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[1] == 1))
                {
                    player.Comandas[1] = 0;
                    player.Comandas[1] = player.Comandas[2];
                    player.Comandas[2] = 0;
                    player.numcomandas--;
                    player.Coger(1);
                }
                else if (Input.GetKeyDown((player.dejar)) && (player.Comandas[2] == 1))
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
