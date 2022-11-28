using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comidas : MonoBehaviour
{
    public int pedido;
    SpriteRenderer spriterender;
    public bool atendido;
    public bool mitadTiempo;

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
    [SerializeField]
    Sprite Esperando1;
    [SerializeField]
    Sprite Esperando2;

    void Start()
    {
        spriterender = GetComponent<SpriteRenderer>();
        atendido = false;
        mitadTiempo = false;

    }
    void Update()
    {
        if (atendido == true)
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
        }else
        {
            if(mitadTiempo == true)
            {
                spriterender.sprite =Esperando2;
            }
            else
            {
                spriterender.sprite = Esperando1;
            }
        }
    }

    public int EstablecerPedido(int pedidoNPC)
    {
        pedido = pedidoNPC;
       
        return pedido;
    }



}
