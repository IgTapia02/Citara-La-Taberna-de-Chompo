using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcolider : MonoBehaviour
{

    public bool atendido;
    void Start()
    {
        atendido = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetKey(GetComponent<Player>().coger))
            {
                atendido = true;
            }
        }
    }
}
