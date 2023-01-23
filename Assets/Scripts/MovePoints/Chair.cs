using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    //waypoint igual que el resto solo que con un tag distinto y una variable fill que se ponje true cuando un npc esta dentro de su colider
    public bool fill;
    public Transform exitpoint;

    void Start()
    {
        fill = false;   
    }
}
