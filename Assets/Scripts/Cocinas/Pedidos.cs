using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedidos : MonoBehaviour
{
    [SerializeField]
    float tiempoCocinado;

    float time;
    public bool Cocinas (int pedido)
    {
            time += Time.deltaTime;
            if (time > tiempoCocinado)
            {
             return true;
            }
        return false;
    }
}
 