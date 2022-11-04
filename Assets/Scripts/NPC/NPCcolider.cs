using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcolider : MonoBehaviour
{

    public bool atendido;
    bool colision;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        atendido = false;
    }
    void Update()
    {
        Debug.Log(colision);
        if (colision == true)
        {
            Debug.Log("istriger");
            if (Input.GetKeyDown((Player.GetComponent<Player>().coger)))
            {
                Debug.Log(atendido);
                atendido = true;
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
