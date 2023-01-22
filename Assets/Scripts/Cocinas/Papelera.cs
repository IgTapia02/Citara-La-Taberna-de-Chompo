using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papelera : MonoBehaviour
{
    Player player;
    bool onColision;

     void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        //se detecta primero si el objeto esta colisionando con el colider papelera
        if(onColision == true)
        {
            //player.dejar es una variable creada en el script player que se coloca desde el motor con esto se invoca el metodo tirar
            if (Input.GetKeyDown(player.dejar))
            {
                tirar();
            }
        }
    }

    //vacia el player.inventario para dejarloa  0
    void tirar()
    {
        player.Inventario[0] = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            onColision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onColision = false;
        }
    }
}
