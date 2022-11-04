using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public bool fill;
    public Transform exitpoint;
    GameObject nextchair;

    void Start()
    {
        fill = false;   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            fill = false;
        }
    }
}
