using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comidas : MonoBehaviour
{
    public int pedido;
    SpriteRenderer spriterender;

    [SerializeField]
    Sprite hamburgesa;
    [SerializeField]
    Sprite huevosPatata;
    [SerializeField]
    Sprite pollo;
    [SerializeField]
    Sprite paella;
    [SerializeField]
    Sprite zumo;
    [SerializeField]
    Sprite tortilla;

    void Start()
    {
        spriterender = GetComponent<SpriteRenderer>();
 
    }
    void Update()
    {
        switch (pedido)
         {
             case 6:
                 spriterender.sprite = paella;
                 break;
             case 5:
                 spriterender.sprite = hamburgesa;
                 break;
             case 4:
                 spriterender.sprite = pollo;
                 break;
             case 3:
                 spriterender.sprite = tortilla;
                 break;
             case 2:
                 spriterender.sprite = huevosPatata;
                 break;
             case 1:
                 spriterender.sprite = zumo;
                 break;
         }
    }

    public int EstablecerPedido(int pedidoNPC)
    {
        pedido = pedidoNPC;

        return pedido;
    }

}
