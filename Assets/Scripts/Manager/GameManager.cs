using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int dineroPJ = 0;
    public TMP_Text Dinero;
    public int dia = 1, mes;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Dinero.text = dineroPJ + "$";
        Debug.Log(dia);
    }

    public void Pagar(int pedido)
    {
        if(pedido == 1)
        {
            dineroPJ += 10;
        }
        if(pedido == 2 || pedido == 3 || pedido == 4 || pedido == 5)
        {
            dineroPJ += 100;
        }
    }
}
