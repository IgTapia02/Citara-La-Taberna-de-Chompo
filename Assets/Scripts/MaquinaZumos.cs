using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaZumos : MonoBehaviour
{
    Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PLayer"))
        {
            if (GetComponent<Player>().Comandas[0] == 1 || GetComponent<Player>().Comandas[1] == 1 || GetComponent<Player>().Comandas[2] == 1)
            {
                player.Coger(1);
            }
        }
    }
}
