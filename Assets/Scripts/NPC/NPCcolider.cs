using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcolider : MonoBehaviour
{

    public bool atendido1,atendido2;
    bool colision;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");//se inicializa el player par las variables coger y dejar
        atendido1 = false;//variable de atendido antes de pedir
        atendido2 = false;//variable de atendido antes de comer
    }
    void Update()
    {
        //se detecta si el player esta colisionando con este colider
        if (colision == true)
        {
            if (Input.GetKeyDown((Player.GetComponent<Player>().coger)))
            {
                atendido1 = true;
            }
            if (Input.GetKeyDown((Player.GetComponent<Player>().dejar)))
            {
                atendido2 = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            colision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            colision = false;
        }
    }

}
