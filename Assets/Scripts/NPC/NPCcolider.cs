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
        Player = GameObject.Find("Player");
        atendido1 = false;
        atendido2 = false;
    }
    void Update()
    {
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
