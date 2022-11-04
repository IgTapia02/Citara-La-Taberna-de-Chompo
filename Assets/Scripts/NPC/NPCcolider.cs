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
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("istriger");
            if (Input.GetKeyDown((other.GetComponent<Player>().coger)))
            {
                Debug.Log(atendido);
                atendido = true;
            }
        }
    }
}
