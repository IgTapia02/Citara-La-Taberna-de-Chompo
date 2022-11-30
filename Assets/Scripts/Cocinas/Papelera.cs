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
        if(onColision == true)
        {
            if(Input.GetKeyDown(player.dejar))
            {
                tirar();
            }
        }
    }


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
