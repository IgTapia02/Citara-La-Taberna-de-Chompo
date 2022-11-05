using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int dineroPJ = 0;
    public TMP_Text Dinero;

    int dia, mes;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = dineroPJ + "$";
    }

    public void Pagar(int pedido)
    {
        if(pedido == 1)
        {
            dineroPJ += 10;
        }
        if(pedido == 2 || pedido == 3 || pedido == 4)
        {
            dineroPJ += 100;
        }
    }
}
